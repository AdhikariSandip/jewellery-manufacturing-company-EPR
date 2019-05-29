namespace Binet_Gold.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Binet_Gold_Model : DbContext
    {
        public Binet_Gold_Model()
            : base("name=Binet_Gold_Model")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill_attribute> Bill_attribute { get; set; }
        public virtual DbSet<Bill_Number> Bill_Number { get; set; }
        public virtual DbSet<Cash_Book> Cash_Book { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract_Persons> Contract_Persons { get; set; }
        public virtual DbSet<Date_Time> Date_Time { get; set; }
        public virtual DbSet<Employee_attribute> Employee_attribute { get; set; }
        public virtual DbSet<Employee_Details> Employee_Details { get; set; }
        public virtual DbSet<EveryDay_rate> EveryDay_rate { get; set; }
        public virtual DbSet<FiscalYear> FiscalYears { get; set; }
        public virtual DbSet<General_Ledger> General_Ledger { get; set; }
        public virtual DbSet<Gold_Issue> Gold_Issue { get; set; }
        public virtual DbSet<Gold_PurchaseRecord> Gold_PurchaseRecord { get; set; }
        public virtual DbSet<Journal_Voucher> Journal_Voucher { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Attribute> Product_Attribute { get; set; }
        public virtual DbSet<Product_Purchase_Record> Product_Purchase_Record { get; set; }
        public virtual DbSet<Purchase_Credits> Purchase_Credits { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<ScrabGold> ScrabGolds { get; set; }
        public virtual DbSet<Shop_Debtor_Account> Shop_Debtor_Account { get; set; }
        public virtual DbSet<Shop_Details> Shop_Details { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Journal_Voucher)
                .WithOptional(e => e.Account1)
                .HasForeignKey(e => e.Account);

            modelBuilder.Entity<Bill_attribute>()
                .Property(e => e.Paid_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bill_attribute>()
                .Property(e => e.Discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bill_Number>()
                .HasMany(e => e.Bill_attribute)
                .WithOptional(e => e.Bill_Number)
                .HasForeignKey(e => e.Bill_NumID);

            modelBuilder.Entity<Bill_Number>()
                .HasMany(e => e.Purchase_Credits)
                .WithOptional(e => e.Bill_Number1)
                .HasForeignKey(e => e.Bill_Number);

            modelBuilder.Entity<Bill_Number>()
                .HasMany(e => e.Shop_Debtor_Account)
                .WithOptional(e => e.Bill_Number1)
                .HasForeignKey(e => e.Bill_Number);

            modelBuilder.Entity<Cash_Book>()
                .Property(e => e.Debit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cash_Book>()
                .Property(e => e.credit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Gold_Issue)
                .WithOptional(e => e.Client1)
                .HasForeignKey(e => e.Client);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Shop_Debtor_Account)
                .WithOptional(e => e.Client1)
                .HasForeignKey(e => e.Client);

            modelBuilder.Entity<Contract_Persons>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Contract_Persons>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Bill_attribute)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Cash_Book)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Contract_Persons)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Employee_attribute)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.EveryDay_rate)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.General_Ledger)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Gold_Issue)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Journal_Voucher)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Product_Attribute)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Purchase_Credits)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Rates)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Date_Time>()
                .HasMany(e => e.Shop_Debtor_Account)
                .WithOptional(e => e.Date_Time)
                .HasForeignKey(e => e.Date);

            modelBuilder.Entity<Employee_attribute>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employee_attribute>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employee_attribute>()
                .Property(e => e.Remaining)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employee_Details>()
                .HasMany(e => e.Contract_Persons)
                .WithOptional(e => e.Employee_Details)
                .HasForeignKey(e => e.CP_Name);

            modelBuilder.Entity<Employee_Details>()
                .HasMany(e => e.Employee_attribute)
                .WithOptional(e => e.Employee_Details)
                .HasForeignKey(e => e.Employee);

            modelBuilder.Entity<EveryDay_rate>()
                .Property(e => e.Bikri_Dar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EveryDay_rate>()
                .Property(e => e.Kharid_Dar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<General_Ledger>()
                .Property(e => e.Debit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<General_Ledger>()
                .Property(e => e.Credit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<General_Ledger>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Gold_Issue>()
                .Property(e => e.Lost_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Gold_Issue>()
                .Property(e => e.Wages)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Gold_PurchaseRecord>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Gold_PurchaseRecord>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Gold_PurchaseRecord>()
                .Property(e => e.Paid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Gold_PurchaseRecord>()
                .Property(e => e.Remaining)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Journal_Voucher>()
                .Property(e => e.Debit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Journal_Voucher>()
                .Property(e => e.Credit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Employee_Details)
                .WithOptional(e => e.Post1)
                .HasForeignKey(e => e.Post);

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.Wages)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product_Attribute>()
                .Property(e => e.Diamond_Stone)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product_Purchase_Record>()
                .HasMany(e => e.Product_Attribute)
                .WithOptional(e => e.Product_Purchase_Record1)
                .HasForeignKey(e => e.Product_Purchase_record);

            modelBuilder.Entity<Product_Purchase_Record>()
                .HasMany(e => e.Purchase_Credits)
                .WithOptional(e => e.Product_Purchase_Record1)
                .HasForeignKey(e => e.Product_purchase_record);

            modelBuilder.Entity<Purchase_Credits>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Purchase_Credits>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Purchase_Credits>()
                .Property(e => e.Total_Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Rate>()
                .Property(e => e.Bikri_Dar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Rate>()
                .Property(e => e.Kharid_Dar)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ScrabGold>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ScrabGold>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Shop_Debtor_Account>()
                .Property(e => e.Total_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Shop_Debtor_Account>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Shop_Debtor_Account>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Bill_attribute)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Bill_Number)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Cash_Book)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Clients)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Contract_Persons)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Employee_attribute)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Employee_Details)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.EveryDay_rate)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.FiscalYears)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.General_Ledger)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Gold_Issue)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Gold_PurchaseRecord)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Journal_Voucher)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_Name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Product_Attribute)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Product_Purchase_Record)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Purchase_Credits)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Rates)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.ScrabGolds)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Shop_Debtor_Account)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);

            modelBuilder.Entity<Shop_Details>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Shop_Details)
                .HasForeignKey(e => e.Shop_name);
        }
    }
}
