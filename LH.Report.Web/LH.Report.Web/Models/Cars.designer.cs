﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevExpress.Web.Demos.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CarsDB")]
	public partial class CarsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertCar(Car instance);
    partial void UpdateCar(Car instance);
    partial void DeleteCar(Car instance);
    partial void InsertCarScheduling(CarScheduling instance);
    partial void UpdateCarScheduling(CarScheduling instance);
    partial void DeleteCarScheduling(CarScheduling instance);
    #endregion
		
		public CarsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["CarsDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Car> Cars
		{
			get
			{
				return this.GetTable<Car>();
			}
		}
		
		public System.Data.Linq.Table<CarScheduling> CarSchedulings
		{
			get
			{
				return this.GetTable<CarScheduling>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cars")]
	public partial class Car : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Trademark;
		
		private string _Model;
		
		private System.Nullable<short> _HP;
		
		private System.Nullable<double> _Liter;
		
		private System.Nullable<byte> _Cyl;
		
		private System.Nullable<byte> _TransmissSpeedCount;
		
		private string _TransmissAutomatic;
		
		private System.Nullable<byte> _MPG_City;
		
		private System.Nullable<byte> _MPG_Highway;
		
		private string _Category;
		
		private string _Description;
		
		private string _Hyperlink;
		
		private System.Data.Linq.Binary _Picture;
		
		private System.Nullable<decimal> _Price;
		
		private string _RtfContent;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTrademarkChanging(string value);
    partial void OnTrademarkChanged();
    partial void OnModelChanging(string value);
    partial void OnModelChanged();
    partial void OnHPChanging(System.Nullable<short> value);
    partial void OnHPChanged();
    partial void OnLiterChanging(System.Nullable<double> value);
    partial void OnLiterChanged();
    partial void OnCylChanging(System.Nullable<byte> value);
    partial void OnCylChanged();
    partial void OnTransmissSpeedCountChanging(System.Nullable<byte> value);
    partial void OnTransmissSpeedCountChanged();
    partial void OnTransmissAutomaticChanging(string value);
    partial void OnTransmissAutomaticChanged();
    partial void OnMPG_CityChanging(System.Nullable<byte> value);
    partial void OnMPG_CityChanged();
    partial void OnMPG_HighwayChanging(System.Nullable<byte> value);
    partial void OnMPG_HighwayChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnHyperlinkChanging(string value);
    partial void OnHyperlinkChanged();
    partial void OnPictureChanging(System.Data.Linq.Binary value);
    partial void OnPictureChanged();
    partial void OnPriceChanging(System.Nullable<decimal> value);
    partial void OnPriceChanged();
    partial void OnRtfContentChanging(string value);
    partial void OnRtfContentChanged();
    #endregion
		
		public Car()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Trademark", DbType="NVarChar(50)")]
		public string Trademark
		{
			get
			{
				return this._Trademark;
			}
			set
			{
				if ((this._Trademark != value))
				{
					this.OnTrademarkChanging(value);
					this.SendPropertyChanging();
					this._Trademark = value;
					this.SendPropertyChanged("Trademark");
					this.OnTrademarkChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Model", DbType="NVarChar(50)")]
		public string Model
		{
			get
			{
				return this._Model;
			}
			set
			{
				if ((this._Model != value))
				{
					this.OnModelChanging(value);
					this.SendPropertyChanging();
					this._Model = value;
					this.SendPropertyChanged("Model");
					this.OnModelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HP", DbType="SmallInt")]
		public System.Nullable<short> HP
		{
			get
			{
				return this._HP;
			}
			set
			{
				if ((this._HP != value))
				{
					this.OnHPChanging(value);
					this.SendPropertyChanging();
					this._HP = value;
					this.SendPropertyChanged("HP");
					this.OnHPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Liter", DbType="Float")]
		public System.Nullable<double> Liter
		{
			get
			{
				return this._Liter;
			}
			set
			{
				if ((this._Liter != value))
				{
					this.OnLiterChanging(value);
					this.SendPropertyChanging();
					this._Liter = value;
					this.SendPropertyChanged("Liter");
					this.OnLiterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cyl", DbType="TinyInt")]
		public System.Nullable<byte> Cyl
		{
			get
			{
				return this._Cyl;
			}
			set
			{
				if ((this._Cyl != value))
				{
					this.OnCylChanging(value);
					this.SendPropertyChanging();
					this._Cyl = value;
					this.SendPropertyChanged("Cyl");
					this.OnCylChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransmissSpeedCount", DbType="TinyInt")]
		public System.Nullable<byte> TransmissSpeedCount
		{
			get
			{
				return this._TransmissSpeedCount;
			}
			set
			{
				if ((this._TransmissSpeedCount != value))
				{
					this.OnTransmissSpeedCountChanging(value);
					this.SendPropertyChanging();
					this._TransmissSpeedCount = value;
					this.SendPropertyChanged("TransmissSpeedCount");
					this.OnTransmissSpeedCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransmissAutomatic", DbType="NVarChar(3)")]
		public string TransmissAutomatic
		{
			get
			{
				return this._TransmissAutomatic;
			}
			set
			{
				if ((this._TransmissAutomatic != value))
				{
					this.OnTransmissAutomaticChanging(value);
					this.SendPropertyChanging();
					this._TransmissAutomatic = value;
					this.SendPropertyChanged("TransmissAutomatic");
					this.OnTransmissAutomaticChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MPG_City", DbType="TinyInt")]
		public System.Nullable<byte> MPG_City
		{
			get
			{
				return this._MPG_City;
			}
			set
			{
				if ((this._MPG_City != value))
				{
					this.OnMPG_CityChanging(value);
					this.SendPropertyChanging();
					this._MPG_City = value;
					this.SendPropertyChanged("MPG_City");
					this.OnMPG_CityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MPG_Highway", DbType="TinyInt")]
		public System.Nullable<byte> MPG_Highway
		{
			get
			{
				return this._MPG_Highway;
			}
			set
			{
				if ((this._MPG_Highway != value))
				{
					this.OnMPG_HighwayChanging(value);
					this.SendPropertyChanging();
					this._MPG_Highway = value;
					this.SendPropertyChanged("MPG_Highway");
					this.OnMPG_HighwayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NVarChar(7)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hyperlink", DbType="NVarChar(50)")]
		public string Hyperlink
		{
			get
			{
				return this._Hyperlink;
			}
			set
			{
				if ((this._Hyperlink != value))
				{
					this.OnHyperlinkChanging(value);
					this.SendPropertyChanging();
					this._Hyperlink = value;
					this.SendPropertyChanged("Hyperlink");
					this.OnHyperlinkChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Picture", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this.OnPictureChanging(value);
					this.SendPropertyChanging();
					this._Picture = value;
					this.SendPropertyChanged("Picture");
					this.OnPictureChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money")]
		public System.Nullable<decimal> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RtfContent", DbType="NVarChar(MAX)")]
		public string RtfContent
		{
			get
			{
				return this._RtfContent;
			}
			set
			{
				if ((this._RtfContent != value))
				{
					this.OnRtfContentChanging(value);
					this.SendPropertyChanging();
					this._RtfContent = value;
					this.SendPropertyChanged("RtfContent");
					this.OnRtfContentChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CarScheduling")]
	public partial class CarScheduling : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _CarId;
		
		private System.Nullable<int> _UserId;
		
		private System.Nullable<int> _Status;
		
		private string _Subject;
		
		private string _Description;
		
		private System.Nullable<int> _Label;
		
		private System.Nullable<System.DateTime> _StartTime;
		
		private System.Nullable<System.DateTime> _EndTime;
		
		private string _Location;
		
		private bool _AllDay;
		
		private System.Nullable<int> _EventType;
		
		private string _RecurrenceInfo;
		
		private string _ReminderInfo;
		
		private System.Nullable<decimal> _Price;
		
		private string _ContactInfo;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnCarIdChanging(System.Nullable<int> value);
    partial void OnCarIdChanged();
    partial void OnUserIdChanging(System.Nullable<int> value);
    partial void OnUserIdChanged();
    partial void OnStatusChanging(System.Nullable<int> value);
    partial void OnStatusChanged();
    partial void OnSubjectChanging(string value);
    partial void OnSubjectChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnLabelChanging(System.Nullable<int> value);
    partial void OnLabelChanged();
    partial void OnStartTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnStartTimeChanged();
    partial void OnEndTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnEndTimeChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnAllDayChanging(bool value);
    partial void OnAllDayChanged();
    partial void OnEventTypeChanging(System.Nullable<int> value);
    partial void OnEventTypeChanged();
    partial void OnRecurrenceInfoChanging(string value);
    partial void OnRecurrenceInfoChanged();
    partial void OnReminderInfoChanging(string value);
    partial void OnReminderInfoChanged();
    partial void OnPriceChanging(System.Nullable<decimal> value);
    partial void OnPriceChanged();
    partial void OnContactInfoChanging(string value);
    partial void OnContactInfoChanged();
    #endregion
		
		public CarScheduling()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarId", DbType="Int")]
		public System.Nullable<int> CarId
		{
			get
			{
				return this._CarId;
			}
			set
			{
				if ((this._CarId != value))
				{
					this.OnCarIdChanging(value);
					this.SendPropertyChanging();
					this._CarId = value;
					this.SendPropertyChanged("CarId");
					this.OnCarIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int")]
		public System.Nullable<int> UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
		public System.Nullable<int> Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="NVarChar(50)")]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this.OnSubjectChanging(value);
					this.SendPropertyChanging();
					this._Subject = value;
					this.SendPropertyChanged("Subject");
					this.OnSubjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Label", DbType="Int")]
		public System.Nullable<int> Label
		{
			get
			{
				return this._Label;
			}
			set
			{
				if ((this._Label != value))
				{
					this.OnLabelChanging(value);
					this.SendPropertyChanging();
					this._Label = value;
					this.SendPropertyChanged("Label");
					this.OnLabelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> StartTime
		{
			get
			{
				return this._StartTime;
			}
			set
			{
				if ((this._StartTime != value))
				{
					this.OnStartTimeChanging(value);
					this.SendPropertyChanging();
					this._StartTime = value;
					this.SendPropertyChanged("StartTime");
					this.OnStartTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> EndTime
		{
			get
			{
				return this._EndTime;
			}
			set
			{
				if ((this._EndTime != value))
				{
					this.OnEndTimeChanging(value);
					this.SendPropertyChanging();
					this._EndTime = value;
					this.SendPropertyChanged("EndTime");
					this.OnEndTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(50)")]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AllDay", DbType="Bit NOT NULL")]
		public bool AllDay
		{
			get
			{
				return this._AllDay;
			}
			set
			{
				if ((this._AllDay != value))
				{
					this.OnAllDayChanging(value);
					this.SendPropertyChanging();
					this._AllDay = value;
					this.SendPropertyChanged("AllDay");
					this.OnAllDayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventType", DbType="Int")]
		public System.Nullable<int> EventType
		{
			get
			{
				return this._EventType;
			}
			set
			{
				if ((this._EventType != value))
				{
					this.OnEventTypeChanging(value);
					this.SendPropertyChanging();
					this._EventType = value;
					this.SendPropertyChanged("EventType");
					this.OnEventTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecurrenceInfo", DbType="NVarChar(MAX)")]
		public string RecurrenceInfo
		{
			get
			{
				return this._RecurrenceInfo;
			}
			set
			{
				if ((this._RecurrenceInfo != value))
				{
					this.OnRecurrenceInfoChanging(value);
					this.SendPropertyChanging();
					this._RecurrenceInfo = value;
					this.SendPropertyChanged("RecurrenceInfo");
					this.OnRecurrenceInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReminderInfo", DbType="NVarChar(MAX)")]
		public string ReminderInfo
		{
			get
			{
				return this._ReminderInfo;
			}
			set
			{
				if ((this._ReminderInfo != value))
				{
					this.OnReminderInfoChanging(value);
					this.SendPropertyChanging();
					this._ReminderInfo = value;
					this.SendPropertyChanged("ReminderInfo");
					this.OnReminderInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="SmallMoney")]
		public System.Nullable<decimal> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContactInfo", DbType="NVarChar(MAX)")]
		public string ContactInfo
		{
			get
			{
				return this._ContactInfo;
			}
			set
			{
				if ((this._ContactInfo != value))
				{
					this.OnContactInfoChanging(value);
					this.SendPropertyChanging();
					this._ContactInfo = value;
					this.SendPropertyChanged("ContactInfo");
					this.OnContactInfoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
