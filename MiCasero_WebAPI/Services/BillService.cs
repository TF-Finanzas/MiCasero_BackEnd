using MiCasero_WebAPI.Data;
using MiCasero_WebAPI.Dtos.Bill;
using MiCasero_WebAPI.Dtos.Customer;
using MiCasero_WebAPI.Interfaces;
using MiCasero_WebAPI.Mappers;
using MiCasero_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiCasero_WebAPI.Services
{
    public class BillService : IBillService
    {
        private readonly ApplicationDBContext _dbContext;
        public BillService(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        public async Task<Bill> CreateBill(CreateBillDTO bill_dto)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == bill_dto.CustomerId);
            if (customer.IsApproved == false)
            {
                return null;
            }
            var bill = bill_dto.FromCreateBillDTOToBill();
            await _dbContext.Bills.AddAsync(bill);
            await _dbContext.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill?> DeleteBill(int id)
        {
            var bill = await _dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);
            if (bill == null)
            {
                return null;
            }
            _dbContext.Bills.Remove(bill);
            await _dbContext.SaveChangesAsync();
            return bill;
        }

        public async Task<decimal> EffectiveRate(int id)
        {
            decimal balance = await _dbContext.Transfers.Where(x => x.BillId == id).SumAsync(x => x.Amount);
            var bill = await _dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);
            if (bill == null || bill.IsEffectiveRate == false)
            {
                return 0;
            }
            bill.Balance = balance;
            int days = bill.FinishDate.DayNumber - bill.StartDate.DayNumber;
            Console.WriteLine($"Days: {days}");
            Console.WriteLine($"Balance: {balance}");
            double future_value = (double)balance * Math.Pow((1 + ((double)bill.InterestRate / 100)), (double)days/360);
            Console.WriteLine($"Future Value: {future_value}");
            decimal interest = (decimal)future_value - bill.Balance;
            interest = Math.Round(interest, 2);
            Console.WriteLine($"Calculated Interest: {interest}");
            return interest;
        }

        public async Task<List<decimal>> FrenchMethod(int id)
        {
            decimal balance = await _dbContext.Transfers.Where(x => x.BillId == id).SumAsync(x => x.Amount);
            var bill = await _dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);
            if (bill == null || bill.IsFrenchMethod == false)
            {
                return null;
            }
            bill.Balance = balance;
            double initialfee = (double)bill.InitialFee/100;
            Console.WriteLine($"InitialFee: {initialfee}");
            double loandiscount = (double)balance*initialfee;
            Console.WriteLine($"loandiscount: {loandiscount}");
            double loan = (double)balance - loandiscount;
            Console.WriteLine($"loan: {loan}");
            int period = (bill.FinishDate.DayNumber - bill.StartDate.DayNumber)/30;
            Console.WriteLine($"period: {period}");
            double interest = (Math.Pow((((double)(bill.InterestRate) / 100) + 1), 30.0 / 360.0) - 1);
            Console.WriteLine($"interest: {interest}");
            List<decimal> revenue = new List<decimal>();
            revenue.Add(Math.Round((decimal)loandiscount, 2));
            double r = 0.0;
            double i = 0.0;
            Console.WriteLine($"revenue: {revenue[0]}");
            for (int x = 1; x <= period; x++)
            {
                i = loan * interest;
                Console.WriteLine($"i: {i}");
                r = loan * ((interest * Math.Pow(1 + interest, period - x + 1)) / (Math.Pow(1 + interest, period - x + 1) - 1));
                Console.WriteLine($"r: {r}");
                revenue.Add(Math.Round(((decimal)r - (decimal)i), 2));
                Console.WriteLine($"revenue: {revenue[x]}");
                loan = loan - (r - i);
                Console.WriteLine($"loan: {loan}");
            }
            return revenue;
        }

        public async Task<decimal> NominalRate(int id)
        {
            decimal balance = await _dbContext.Transfers.Where(x => x.BillId == id).SumAsync(x => x.Amount);
            var bill = await _dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);
            if (bill == null || bill.IsNominalRate == false)
            {
                return 0;
            }
            bill.Balance = balance;
            int days = bill.FinishDate.DayNumber - bill.StartDate.DayNumber;
            double n = (double)days / 30;
            int m = 360 / 30;
            Console.WriteLine($"Days: {days}, Periods (n): {n}, Periods in a year (m): {m}");
            double future_value = (double)balance * Math.Pow(1 + ((double)bill.InterestRate / 100) / m, n);
            Console.WriteLine($"Future Value: {future_value}");
            decimal interest = (decimal)future_value - bill.Balance;
            interest = Math.Round(interest, 2);
            Console.WriteLine($"Calculated Interest: {interest}");
            return interest;
        }



        public async Task<List<ReadBillDTO?>> ReadBill(int id)
        {
            var bills = await _dbContext.Bills.Where(x => x.CustomerId == id)
                                .Select(bill => (ReadBillDTO?)bill.ToReadBillDTO())
                                .ToListAsync();
            return bills;
        }

        public async Task UpdateBalance(int id)
        {
            decimal balance = await _dbContext.Transfers.Where(x => x.BillId == id).SumAsync(x => x.Amount);
            var bill = await _dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);

            if (bill == null)
            {
                Console.WriteLine($"Bill con id {id} no encontrado.");
                return;
            }

            Console.WriteLine($"Balance calculado: {balance}");

            if (bill.IsEffectiveRate == true || bill.IsNominalRate == true)
            {
                bill.Balance = balance;
                Console.WriteLine($"Balance actualizado a: {balance}");
            }
            else if (bill.IsFrenchMethod == true)
            {
                decimal share = await _dbContext.Transfers.Where(x => x.BillId == id && x.Name == "Interest").SumAsync(x => x.Amount);
                bill.Balance = balance - share;
                Console.WriteLine($"Balance después de restar el interés ({share}): {bill.Balance}");
            }

            await _dbContext.SaveChangesAsync();
            Console.WriteLine("Cambios guardados.");
        }
    }
}
