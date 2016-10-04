USE [master]
GO
/****** Object:  Database [TruckApp]    Script Date: 2016/10/04 2:39:12 PM ******/
CREATE DATABASE [TruckApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TruckApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TruckApp.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TruckApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TruckApp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TruckApp] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TruckApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TruckApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TruckApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TruckApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TruckApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TruckApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [TruckApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TruckApp] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TruckApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TruckApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TruckApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TruckApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TruckApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TruckApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TruckApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TruckApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TruckApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TruckApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TruckApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TruckApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TruckApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TruckApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TruckApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TruckApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TruckApp] SET RECOVERY FULL 
GO
ALTER DATABASE [TruckApp] SET  MULTI_USER 
GO
ALTER DATABASE [TruckApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TruckApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TruckApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TruckApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TruckApp', N'ON'
GO
USE [TruckApp]
GO
/****** Object:  Table [dbo].[BookingGoods]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingGoods](
	[goods_id] [int] IDENTITY(1,1) NOT NULL,
	[goods_type] [varchar](50) NOT NULL,
	[goods_description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_BookingGoods] PRIMARY KEY CLUSTERED 
(
	[goods_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookingTruck]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingTruck](
	[booking_id] [int] IDENTITY(1,1) NOT NULL,
	[booking_date_made] [date] NOT NULL,
	[booking_departure_date] [date] NOT NULL,
	[booking_arrival_date] [date] NOT NULL,
	[departure_street_number] [varchar](10) NOT NULL,
	[departure_street_name] [varchar](50) NOT NULL,
	[departure_street_area] [varchar](50) NOT NULL,
	[departure_city] [varchar](50) NOT NULL,
	[arrival_street_number] [varchar](10) NOT NULL,
	[arrival_street_name] [varchar](50) NOT NULL,
	[arrival_street_area] [varchar](50) NOT NULL,
	[arrival_city] [varchar](50) NOT NULL,
	[truck_id] [int] NOT NULL,
	[staff_id] [int] NOT NULL,
	[goods_id] [int] NOT NULL,
	[booking_notes] [varchar](250) NOT NULL,
	[client_id] [int] NOT NULL,
	[driver_id] [int] NOT NULL,
	[delivery_distance] [int] NULL,
 CONSTRAINT [PK_BookingTruck] PRIMARY KEY CLUSTERED 
(
	[booking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[client_id] [int] IDENTITY(1,1) NOT NULL,
	[client_firstname] [varchar](50) NOT NULL,
	[client_lastname] [varchar](50) NOT NULL,
	[business_name] [varchar](50) NOT NULL,
	[client_landline] [varchar](15) NOT NULL,
	[client_cellphone] [varchar](10) NOT NULL,
	[client_address_street] [varchar](50) NOT NULL,
	[client_address_number] [varchar](10) NOT NULL,
	[client_address_area] [varchar](50) NOT NULL,
	[client_address_areacode] [varchar](50) NOT NULL,
	[client_city] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DriversLiscenceCodes]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DriversLiscenceCodes](
	[licence_code_id] [int] NOT NULL,
	[code_type] [varchar](50) NOT NULL,
	[code_description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_DriversLiscenceCodes] PRIMARY KEY CLUSTERED 
(
	[licence_code_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[staff_id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](100) NOT NULL,
	[id_number] [varchar](13) NOT NULL,
	[cellphone_number] [varchar](10) NOT NULL,
	[street_number] [int] NOT NULL,
	[street_name] [varchar](50) NOT NULL,
	[street_area] [varchar](50) NOT NULL,
	[address_province] [varchar](50) NOT NULL,
	[address_city] [varchar](50) NOT NULL,
	[department_id] [int] NOT NULL,
	[licence_code_id] [int] NOT NULL,
	[banking_id] [int] NOT NULL,
	[login_id] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[staff_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaffBankingDetails]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffBankingDetails](
	[banking_id] [int] IDENTITY(1,1) NOT NULL,
	[bank_name] [varchar](50) NOT NULL,
	[account_type] [varchar](50) NOT NULL,
	[account_number] [varchar](50) NOT NULL,
	[branch_name] [varchar](50) NOT NULL,
	[branch_code] [varchar](10) NOT NULL,
 CONSTRAINT [PK_StaffBankingDetails] PRIMARY KEY CLUSTERED 
(
	[banking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaffDepartments]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffDepartments](
	[department_id] [int] IDENTITY(1,1) NOT NULL,
	[department_name] [varchar](50) NOT NULL,
	[department_description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_StaffDepartments] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaffLogin]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffLogin](
	[login_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StaffLogin] PRIMARY KEY CLUSTERED 
(
	[login_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TruckDrivers]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruckDrivers](
	[driver_id] [int] IDENTITY(1,1) NOT NULL,
	[staff_id] [int] NOT NULL,
 CONSTRAINT [PK_TruckDrivers] PRIMARY KEY CLUSTERED 
(
	[driver_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TruckMaintenance]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruckMaintenance](
	[maintenance_id] [int] IDENTITY(1,1) NOT NULL,
	[kilos_serviced] [int] NOT NULL,
	[date_last_service] [date] NOT NULL,
	[date_tires_renewed] [date] NOT NULL,
 CONSTRAINT [PK_TruckMaintenance] PRIMARY KEY CLUSTERED 
(
	[maintenance_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trucks]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trucks](
	[truck_id] [int] IDENTITY(1,1) NOT NULL,
	[truck_registration] [varchar](50) NOT NULL,
	[truck_weight] [int] NOT NULL,
	[truck_capacity] [int] NOT NULL,
	[truck_type] [varchar](50) NOT NULL,
	[truck_kilos] [int] NOT NULL,
	[body_type_trailer] [varchar](50) NOT NULL,
	[licence_code_id] [int] NOT NULL,
	[mode_type] [varchar](50) NOT NULL,
	[horse_power] [varchar](50) NOT NULL,
	[fuel_tank_litre] [int] NOT NULL,
	[fuel_usage_kilo] [int] NOT NULL,
	[sleeping_type_id] [int] NOT NULL,
	[maintenance_id] [int] NOT NULL,
 CONSTRAINT [PK_Trucks] PRIMARY KEY CLUSTERED 
(
	[truck_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TruckSleepTypes]    Script Date: 2016/10/04 2:39:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TruckSleepTypes](
	[sleeping_type_id] [int] NOT NULL,
	[type_name] [varchar](50) NOT NULL,
	[type_description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_TruckSleepTypes] PRIMARY KEY CLUSTERED 
(
	[sleeping_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BookingGoods] ([goods_type], [goods_description]) VALUES (N'Food', N'Perishable Food')
INSERT [dbo].[BookingGoods] ([goods_type], [goods_description]) VALUES (N'Liquid', N'Liquid-form cargo')
INSERT [dbo].[BookingGoods] ([goods_type], [goods_description]) VALUES (N'Industrial', N'Industrial-based goods')
INSERT [dbo].[DriversLiscenceCodes] ([licence_code_id], [code_type], [code_description]) VALUES (0, N'C1', N'Vehicles with tare weight between 3 500 kg and 16 000 kg; minibuses, buses and goods vehicles with GVM between 3 500 kg and 16 000 kg. A trailer with GVM of 750 kg or less may be attached.')
INSERT [dbo].[DriversLiscenceCodes] ([licence_code_id], [code_type], [code_description]) VALUES (1, N'C', N'Buses and goods vehicles with GVM greater than 16 000 kg. A trailer with GVM of 750 kg or less may be attached.')
INSERT [dbo].[DriversLiscenceCodes] ([licence_code_id], [code_type], [code_description]) VALUES (2, N'EC1', N'Articulated vehicles with GCM between 3 500 kg and 16 000 kg; and vehicles allowed by Code C1 but with a trailer with GVM greater than 750 kg.')
INSERT [dbo].[DriversLiscenceCodes] ([licence_code_id], [code_type], [code_description]) VALUES (3, N'EC', N'Articulated vehicles with GCM greater than 18 000 kg; and vehicles allowed by Code C but with a trailer with GVM greater than 750 kg.')
SET IDENTITY_INSERT [dbo].[StaffBankingDetails] ON 

INSERT [dbo].[StaffBankingDetails] ([banking_id], [bank_name], [account_type], [account_number], [branch_name], [branch_code]) VALUES (1, N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[StaffBankingDetails] OFF
SET IDENTITY_INSERT [dbo].[StaffLogin] ON 

INSERT [dbo].[StaffLogin] ([login_id], [username], [password]) VALUES (1, N'', N'')
SET IDENTITY_INSERT [dbo].[StaffLogin] OFF
SET IDENTITY_INSERT [dbo].[TruckMaintenance] ON 

INSERT [dbo].[TruckMaintenance] ([maintenance_id], [kilos_serviced], [date_last_service], [date_tires_renewed]) VALUES (15, 2000, CAST(N'2016-09-05' AS Date), CAST(N'2016-01-01' AS Date))
INSERT [dbo].[TruckMaintenance] ([maintenance_id], [kilos_serviced], [date_last_service], [date_tires_renewed]) VALUES (16, 0, CAST(N'2016-10-03' AS Date), CAST(N'2016-10-03' AS Date))
SET IDENTITY_INSERT [dbo].[TruckMaintenance] OFF
SET IDENTITY_INSERT [dbo].[Trucks] ON 

INSERT [dbo].[Trucks] ([truck_id], [truck_registration], [truck_weight], [truck_capacity], [truck_type], [truck_kilos], [body_type_trailer], [licence_code_id], [mode_type], [horse_power], [fuel_tank_litre], [fuel_usage_kilo], [sleeping_type_id], [maintenance_id]) VALUES (10, N'DP8898GP', 8000, 3000, N'Loader', 45000, N'Fixed', 3, N'Man', N'200', 120, 8, 0, 15)
INSERT [dbo].[Trucks] ([truck_id], [truck_registration], [truck_weight], [truck_capacity], [truck_type], [truck_kilos], [body_type_trailer], [licence_code_id], [mode_type], [horse_power], [fuel_tank_litre], [fuel_usage_kilo], [sleeping_type_id], [maintenance_id]) VALUES (11, N'0', 0, 0, N'0', 0, N'0', 0, N'0', N'0', 0, 0, 0, 16)
SET IDENTITY_INSERT [dbo].[Trucks] OFF
INSERT [dbo].[TruckSleepTypes] ([sleeping_type_id], [type_name], [type_description]) VALUES (0, N'Sleeper', N'Facilitates Sleeping')
INSERT [dbo].[TruckSleepTypes] ([sleeping_type_id], [type_name], [type_description]) VALUES (1, N'Non-Sleeper', N'Does not facilitate sleeping')
ALTER TABLE [dbo].[BookingTruck]  WITH CHECK ADD  CONSTRAINT [FK_BookingTruck_BookingGoods] FOREIGN KEY([goods_id])
REFERENCES [dbo].[BookingGoods] ([goods_id])
GO
ALTER TABLE [dbo].[BookingTruck] CHECK CONSTRAINT [FK_BookingTruck_BookingGoods]
GO
ALTER TABLE [dbo].[BookingTruck]  WITH CHECK ADD  CONSTRAINT [FK_BookingTruck_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([client_id])
GO
ALTER TABLE [dbo].[BookingTruck] CHECK CONSTRAINT [FK_BookingTruck_Clients]
GO
ALTER TABLE [dbo].[BookingTruck]  WITH CHECK ADD  CONSTRAINT [FK_BookingTruck_Staff] FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([staff_id])
GO
ALTER TABLE [dbo].[BookingTruck] CHECK CONSTRAINT [FK_BookingTruck_Staff]
GO
ALTER TABLE [dbo].[BookingTruck]  WITH CHECK ADD  CONSTRAINT [FK_BookingTruck_TruckDrivers] FOREIGN KEY([driver_id])
REFERENCES [dbo].[TruckDrivers] ([driver_id])
GO
ALTER TABLE [dbo].[BookingTruck] CHECK CONSTRAINT [FK_BookingTruck_TruckDrivers]
GO
ALTER TABLE [dbo].[BookingTruck]  WITH CHECK ADD  CONSTRAINT [FK_BookingTruck_Trucks] FOREIGN KEY([truck_id])
REFERENCES [dbo].[Trucks] ([truck_id])
GO
ALTER TABLE [dbo].[BookingTruck] CHECK CONSTRAINT [FK_BookingTruck_Trucks]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_DriversLiscenceCodes] FOREIGN KEY([licence_code_id])
REFERENCES [dbo].[DriversLiscenceCodes] ([licence_code_id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_DriversLiscenceCodes]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_StaffBankingDetails] FOREIGN KEY([banking_id])
REFERENCES [dbo].[StaffBankingDetails] ([banking_id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_StaffBankingDetails]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_StaffDepartments] FOREIGN KEY([department_id])
REFERENCES [dbo].[StaffDepartments] ([department_id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_StaffDepartments]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_StaffLogin] FOREIGN KEY([login_id])
REFERENCES [dbo].[StaffLogin] ([login_id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_StaffLogin]
GO
ALTER TABLE [dbo].[TruckDrivers]  WITH CHECK ADD  CONSTRAINT [FK_TruckDrivers_Staff] FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([staff_id])
GO
ALTER TABLE [dbo].[TruckDrivers] CHECK CONSTRAINT [FK_TruckDrivers_Staff]
GO
ALTER TABLE [dbo].[Trucks]  WITH CHECK ADD  CONSTRAINT [FK_Trucks_DriversLiscenceCodes] FOREIGN KEY([licence_code_id])
REFERENCES [dbo].[DriversLiscenceCodes] ([licence_code_id])
GO
ALTER TABLE [dbo].[Trucks] CHECK CONSTRAINT [FK_Trucks_DriversLiscenceCodes]
GO
ALTER TABLE [dbo].[Trucks]  WITH CHECK ADD  CONSTRAINT [FK_Trucks_TruckMaintenance] FOREIGN KEY([maintenance_id])
REFERENCES [dbo].[TruckMaintenance] ([maintenance_id])
GO
ALTER TABLE [dbo].[Trucks] CHECK CONSTRAINT [FK_Trucks_TruckMaintenance]
GO
ALTER TABLE [dbo].[Trucks]  WITH CHECK ADD  CONSTRAINT [FK_Trucks_TruckSleepTypes] FOREIGN KEY([sleeping_type_id])
REFERENCES [dbo].[TruckSleepTypes] ([sleeping_type_id])
GO
ALTER TABLE [dbo].[Trucks] CHECK CONSTRAINT [FK_Trucks_TruckSleepTypes]
GO
USE [master]
GO
ALTER DATABASE [TruckApp] SET  READ_WRITE 
GO
