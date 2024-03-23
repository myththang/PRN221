USE [master]
GO
/****** Object:  Database [PRN221_Project]    Script Date: 3/22/2024 6:37:20 PM ******/
CREATE DATABASE [PRN221_Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN221_Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PRN221_Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN221_Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PRN221_Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PRN221_Project] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN221_Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN221_Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN221_Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN221_Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN221_Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN221_Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN221_Project] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PRN221_Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN221_Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN221_Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN221_Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN221_Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN221_Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN221_Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN221_Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN221_Project] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRN221_Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN221_Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN221_Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN221_Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN221_Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN221_Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN221_Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN221_Project] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN221_Project] SET  MULTI_USER 
GO
ALTER DATABASE [PRN221_Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN221_Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN221_Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN221_Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN221_Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN221_Project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PRN221_Project] SET QUERY_STORE = ON
GO
ALTER DATABASE [PRN221_Project] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PRN221_Project]
GO
/****** Object:  Table [dbo].[AutomatedTransactions]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutomatedTransactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[TransactionDate] [date] NULL,
	[Amount] [decimal](15, 2) NULL,
	[Type] [varchar](50) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Budgets]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Budgets](
	[BudgetID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Month] [date] NULL,
	[TotalBudget] [decimal](15, 2) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[BudgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[CurrencyID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [varchar](5) NULL,
	[CurrencyName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DebtsLoans]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebtsLoans](
	[DebtLoanID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Type] [varchar](50) NULL,
	[Amount] [decimal](15, 2) NULL,
	[InterestRate] [decimal](5, 2) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[DebtLoanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeRates]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRates](
	[RateID] [int] IDENTITY(1,1) NOT NULL,
	[FromCurrencyID] [int] NULL,
	[ToCurrencyID] [int] NULL,
	[Rate] [decimal](15, 6) NULL,
PRIMARY KEY CLUSTERED 
(
	[RateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[ExpenseID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ExpenseDate] [date] NULL,
	[Amount] [decimal](15, 2) NULL,
	[Category] [varchar](50) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExpenseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinancialProducts]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinancialProducts](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NULL,
	[Type] [varchar](50) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Income]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[IncomeID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[IncomeDate] [date] NULL,
	[Amount] [decimal](15, 2) NULL,
	[Source] [varchar](50) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[IncomeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Investments]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Investments](
	[InvestmentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[InvestmentType] [varchar](50) NULL,
	[InvestmentDate] [date] NULL,
	[Amount] [decimal](15, 2) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvestmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentReminders]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentReminders](
	[ReminderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ReminderDate] [date] NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReminderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductComparisons]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductComparisons](
	[ComparisonID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ProductID] [int] NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ComparisonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Security]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Security](
	[SecurityID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[EncryptionKey] [varchar](100) NULL,
	[LastLogin] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SecurityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionLogs]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionLogs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[TransactionDate] [date] NULL,
	[Amount] [decimal](15, 2) NULL,
	[Type] [varchar](50) NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/22/2024 6:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Balance] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AutomatedTransactions] ON 

INSERT [dbo].[AutomatedTransactions] ([TransactionID], [UserID], [TransactionDate], [Amount], [Type], [Description]) VALUES (1, 1, CAST(N'2024-03-28' AS Date), CAST(2000000.00 AS Decimal(15, 2)), N'Transfer', N'Transfer to savings account')
INSERT [dbo].[AutomatedTransactions] ([TransactionID], [UserID], [TransactionDate], [Amount], [Type], [Description]) VALUES (2, 1, CAST(N'2024-03-27' AS Date), CAST(1500000.00 AS Decimal(15, 2)), N'Bill Payment', N'Utility bill payment')
SET IDENTITY_INSERT [dbo].[AutomatedTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Budgets] ON 

INSERT [dbo].[Budgets] ([BudgetID], [UserID], [Month], [TotalBudget], [Description]) VALUES (1, NULL, CAST(N'2024-03-01' AS Date), CAST(5000000.00 AS Decimal(15, 2)), N'Monthly budget for March')
INSERT [dbo].[Budgets] ([BudgetID], [UserID], [Month], [TotalBudget], [Description]) VALUES (2, NULL, CAST(N'2024-03-01' AS Date), CAST(4000000.00 AS Decimal(15, 2)), N'Monthly budget for March')
SET IDENTITY_INSERT [dbo].[Budgets] OFF
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName]) VALUES (1, N'VND', N'Vietnamese Dong')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName]) VALUES (2, N'USD', N'US Dollar')
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyCode], [CurrencyName]) VALUES (3, N'EUR', N'Euro')
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
SET IDENTITY_INSERT [dbo].[DebtsLoans] ON 

INSERT [dbo].[DebtsLoans] ([DebtLoanID], [UserID], [Type], [Amount], [InterestRate], [Description]) VALUES (3, 1, N'Credit Card', CAST(1000000.00 AS Decimal(15, 2)), CAST(0.15 AS Decimal(5, 2)), N'Credit card debt')
INSERT [dbo].[DebtsLoans] ([DebtLoanID], [UserID], [Type], [Amount], [InterestRate], [Description]) VALUES (4, 2, N'Student Loan', CAST(2000000.00 AS Decimal(15, 2)), CAST(0.10 AS Decimal(5, 2)), N'Student loan debt')
SET IDENTITY_INSERT [dbo].[DebtsLoans] OFF
GO
SET IDENTITY_INSERT [dbo].[ExchangeRates] ON 

INSERT [dbo].[ExchangeRates] ([RateID], [FromCurrencyID], [ToCurrencyID], [Rate]) VALUES (1, 1, 2, CAST(0.000040 AS Decimal(15, 6)))
INSERT [dbo].[ExchangeRates] ([RateID], [FromCurrencyID], [ToCurrencyID], [Rate]) VALUES (2, 1, 3, CAST(0.000037 AS Decimal(15, 6)))
INSERT [dbo].[ExchangeRates] ([RateID], [FromCurrencyID], [ToCurrencyID], [Rate]) VALUES (3, 2, 1, CAST(24770.000000 AS Decimal(15, 6)))
INSERT [dbo].[ExchangeRates] ([RateID], [FromCurrencyID], [ToCurrencyID], [Rate]) VALUES (4, 2, 3, CAST(0.920000 AS Decimal(15, 6)))
INSERT [dbo].[ExchangeRates] ([RateID], [FromCurrencyID], [ToCurrencyID], [Rate]) VALUES (5, 3, 1, CAST(26805.970000 AS Decimal(15, 6)))
INSERT [dbo].[ExchangeRates] ([RateID], [FromCurrencyID], [ToCurrencyID], [Rate]) VALUES (6, 3, 2, CAST(1.080000 AS Decimal(15, 6)))
SET IDENTITY_INSERT [dbo].[ExchangeRates] OFF
GO
SET IDENTITY_INSERT [dbo].[Expenses] ON 

INSERT [dbo].[Expenses] ([ExpenseID], [UserID], [ExpenseDate], [Amount], [Category], [Description]) VALUES (1, 1, CAST(N'2024-03-22' AS Date), CAST(12000.00 AS Decimal(15, 2)), N'Food', N'Candy')
INSERT [dbo].[Expenses] ([ExpenseID], [UserID], [ExpenseDate], [Amount], [Category], [Description]) VALUES (2, 1, CAST(N'2024-03-22' AS Date), CAST(500000.00 AS Decimal(15, 2)), N'Grocery', N'Grocery shopping')
INSERT [dbo].[Expenses] ([ExpenseID], [UserID], [ExpenseDate], [Amount], [Category], [Description]) VALUES (3, 1, CAST(N'2024-03-22' AS Date), CAST(1.00 AS Decimal(15, 2)), N'Food', N'1')
INSERT [dbo].[Expenses] ([ExpenseID], [UserID], [ExpenseDate], [Amount], [Category], [Description]) VALUES (4, 1, CAST(N'2024-03-22' AS Date), CAST(10000.00 AS Decimal(15, 2)), N'Food', N'123')
SET IDENTITY_INSERT [dbo].[Expenses] OFF
GO
SET IDENTITY_INSERT [dbo].[FinancialProducts] ON 

INSERT [dbo].[FinancialProducts] ([ProductID], [ProductName], [Type], [Description]) VALUES (1, N'Life Insurance', N'Insurance', N'Provides life insurance coverage')
INSERT [dbo].[FinancialProducts] ([ProductID], [ProductName], [Type], [Description]) VALUES (2, N'Personal Loan', N'Loan', N'Offers personal loans at competitive rates')
SET IDENTITY_INSERT [dbo].[FinancialProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Balance]) VALUES (1, N'thang', N'123', N'a@gmail.com', 9990000.0000)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Balance]) VALUES (2, N'user1', N'password1', N'user1@example.com', 20000000.0000)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Balance]) VALUES (3, N'user2', N'password2', N'user2@example.com', 30000000.0000)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[AutomatedTransactions]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Budgets]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[DebtsLoans]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ExchangeRates]  WITH CHECK ADD FOREIGN KEY([FromCurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
ALTER TABLE [dbo].[ExchangeRates]  WITH CHECK ADD FOREIGN KEY([ToCurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Income]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Investments]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PaymentReminders]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ProductComparisons]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[FinancialProducts] ([ProductID])
GO
ALTER TABLE [dbo].[ProductComparisons]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Security]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[TransactionLogs]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [PRN221_Project] SET  READ_WRITE 
GO
