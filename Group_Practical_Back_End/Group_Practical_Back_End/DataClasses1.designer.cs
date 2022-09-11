﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group_Practical_Back_End
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertSeller(Seller instance);
    partial void UpdateSeller(Seller instance);
    partial void DeleteSeller(Seller instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Seller> Sellers
		{
			get
			{
				return this.GetTable<Seller>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Username;
		
		private string _First_Name;
		
		private string _Surname;
		
		private string _Email;
		
		private string _Password;
		
		private int _User_Type;
		
		private string _Phone;
		
		private string _Cart_Items;
		
		private string _Wish_List;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnFirst_NameChanging(string value);
    partial void OnFirst_NameChanged();
    partial void OnSurnameChanging(string value);
    partial void OnSurnameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnUser_TypeChanging(int value);
    partial void OnUser_TypeChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnCart_ItemsChanging(string value);
    partial void OnCart_ItemsChanged();
    partial void OnWish_ListChanging(string value);
    partial void OnWish_ListChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_First_Name", DbType="VarChar(255)")]
		public string First_Name
		{
			get
			{
				return this._First_Name;
			}
			set
			{
				if ((this._First_Name != value))
				{
					this.OnFirst_NameChanging(value);
					this.SendPropertyChanging();
					this._First_Name = value;
					this.SendPropertyChanged("First_Name");
					this.OnFirst_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="VarChar(255)")]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this.OnSurnameChanging(value);
					this.SendPropertyChanging();
					this._Surname = value;
					this.SendPropertyChanged("Surname");
					this.OnSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_Type", DbType="Int NOT NULL")]
		public int User_Type
		{
			get
			{
				return this._User_Type;
			}
			set
			{
				if ((this._User_Type != value))
				{
					this.OnUser_TypeChanging(value);
					this.SendPropertyChanging();
					this._User_Type = value;
					this.SendPropertyChanged("User_Type");
					this.OnUser_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(50)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cart_Items", DbType="VarChar(MAX)")]
		public string Cart_Items
		{
			get
			{
				return this._Cart_Items;
			}
			set
			{
				if ((this._Cart_Items != value))
				{
					this.OnCart_ItemsChanging(value);
					this.SendPropertyChanging();
					this._Cart_Items = value;
					this.SendPropertyChanged("Cart_Items");
					this.OnCart_ItemsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wish_List", DbType="VarChar(MAX)")]
		public string Wish_List
		{
			get
			{
				return this._Wish_List;
			}
			set
			{
				if ((this._Wish_List != value))
				{
					this.OnWish_ListChanging(value);
					this.SendPropertyChanging();
					this._Wish_List = value;
					this.SendPropertyChanged("Wish_List");
					this.OnWish_ListChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Seller")]
	public partial class Seller : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _S_Name;
		
		private string _S_Surname;
		
		private string _Username;
		
		private string _Email;
		
		private string _Phone;
		
		private string _Password;
		
		private string _Identity_Number;
		
		private int _Average_Rating;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnS_NameChanging(string value);
    partial void OnS_NameChanged();
    partial void OnS_SurnameChanging(string value);
    partial void OnS_SurnameChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnIdentity_NumberChanging(string value);
    partial void OnIdentity_NumberChanged();
    partial void OnAverage_RatingChanging(int value);
    partial void OnAverage_RatingChanged();
    #endregion
		
		public Seller()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_S_Name", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string S_Name
		{
			get
			{
				return this._S_Name;
			}
			set
			{
				if ((this._S_Name != value))
				{
					this.OnS_NameChanging(value);
					this.SendPropertyChanging();
					this._S_Name = value;
					this.SendPropertyChanged("S_Name");
					this.OnS_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_S_Surname", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string S_Surname
		{
			get
			{
				return this._S_Surname;
			}
			set
			{
				if ((this._S_Surname != value))
				{
					this.OnS_SurnameChanging(value);
					this.SendPropertyChanging();
					this._S_Surname = value;
					this.SendPropertyChanged("S_Surname");
					this.OnS_SurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(255)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Identity_Number", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Identity_Number
		{
			get
			{
				return this._Identity_Number;
			}
			set
			{
				if ((this._Identity_Number != value))
				{
					this.OnIdentity_NumberChanging(value);
					this.SendPropertyChanging();
					this._Identity_Number = value;
					this.SendPropertyChanged("Identity_Number");
					this.OnIdentity_NumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Average_Rating", DbType="Int NOT NULL")]
		public int Average_Rating
		{
			get
			{
				return this._Average_Rating;
			}
			set
			{
				if ((this._Average_Rating != value))
				{
					this.OnAverage_RatingChanging(value);
					this.SendPropertyChanging();
					this._Average_Rating = value;
					this.SendPropertyChanged("Average_Rating");
					this.OnAverage_RatingChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Product_Name;
		
		private decimal _Product_Price;
		
		private System.Nullable<decimal> _Discount_Price;
		
		private string _Category;
		
		private string _Image;
		
		private int _Available;
		
		private int _Seller_ID;
		
		private string _Color;
		
		private string _Description;
		
		private decimal _Weight_KG;
		
		private string _Dimensions_XYZ;
		
		private string _Manufacturer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnProduct_NameChanging(string value);
    partial void OnProduct_NameChanged();
    partial void OnProduct_PriceChanging(decimal value);
    partial void OnProduct_PriceChanged();
    partial void OnDiscount_PriceChanging(System.Nullable<decimal> value);
    partial void OnDiscount_PriceChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnImageChanging(string value);
    partial void OnImageChanged();
    partial void OnAvailableChanging(int value);
    partial void OnAvailableChanged();
    partial void OnSeller_IDChanging(int value);
    partial void OnSeller_IDChanged();
    partial void OnColorChanging(string value);
    partial void OnColorChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnWeight_KGChanging(decimal value);
    partial void OnWeight_KGChanged();
    partial void OnDimensions_XYZChanging(string value);
    partial void OnDimensions_XYZChanged();
    partial void OnManufacturerChanging(string value);
    partial void OnManufacturerChanged();
    #endregion
		
		public Product()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Name", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Product_Name
		{
			get
			{
				return this._Product_Name;
			}
			set
			{
				if ((this._Product_Name != value))
				{
					this.OnProduct_NameChanging(value);
					this.SendPropertyChanging();
					this._Product_Name = value;
					this.SendPropertyChanged("Product_Name");
					this.OnProduct_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Product_Price", DbType="Money NOT NULL")]
		public decimal Product_Price
		{
			get
			{
				return this._Product_Price;
			}
			set
			{
				if ((this._Product_Price != value))
				{
					this.OnProduct_PriceChanging(value);
					this.SendPropertyChanging();
					this._Product_Price = value;
					this.SendPropertyChanged("Product_Price");
					this.OnProduct_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Discount_Price", DbType="Money")]
		public System.Nullable<decimal> Discount_Price
		{
			get
			{
				return this._Discount_Price;
			}
			set
			{
				if ((this._Discount_Price != value))
				{
					this.OnDiscount_PriceChanging(value);
					this.SendPropertyChanging();
					this._Discount_Price = value;
					this.SendPropertyChanged("Discount_Price");
					this.OnDiscount_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Available", DbType="Int NOT NULL")]
		public int Available
		{
			get
			{
				return this._Available;
			}
			set
			{
				if ((this._Available != value))
				{
					this.OnAvailableChanging(value);
					this.SendPropertyChanging();
					this._Available = value;
					this.SendPropertyChanged("Available");
					this.OnAvailableChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Seller_ID", DbType="Int NOT NULL")]
		public int Seller_ID
		{
			get
			{
				return this._Seller_ID;
			}
			set
			{
				if ((this._Seller_ID != value))
				{
					this.OnSeller_IDChanging(value);
					this.SendPropertyChanging();
					this._Seller_ID = value;
					this.SendPropertyChanged("Seller_ID");
					this.OnSeller_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Color", DbType="VarChar(255)")]
		public string Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				if ((this._Color != value))
				{
					this.OnColorChanging(value);
					this.SendPropertyChanging();
					this._Color = value;
					this.SendPropertyChanged("Color");
					this.OnColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weight_KG", DbType="Money NOT NULL")]
		public decimal Weight_KG
		{
			get
			{
				return this._Weight_KG;
			}
			set
			{
				if ((this._Weight_KG != value))
				{
					this.OnWeight_KGChanging(value);
					this.SendPropertyChanging();
					this._Weight_KG = value;
					this.SendPropertyChanged("Weight_KG");
					this.OnWeight_KGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dimensions_XYZ", DbType="VarChar(255)")]
		public string Dimensions_XYZ
		{
			get
			{
				return this._Dimensions_XYZ;
			}
			set
			{
				if ((this._Dimensions_XYZ != value))
				{
					this.OnDimensions_XYZChanging(value);
					this.SendPropertyChanging();
					this._Dimensions_XYZ = value;
					this.SendPropertyChanged("Dimensions_XYZ");
					this.OnDimensions_XYZChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Manufacturer", DbType="VarChar(255)")]
		public string Manufacturer
		{
			get
			{
				return this._Manufacturer;
			}
			set
			{
				if ((this._Manufacturer != value))
				{
					this.OnManufacturerChanging(value);
					this.SendPropertyChanging();
					this._Manufacturer = value;
					this.SendPropertyChanged("Manufacturer");
					this.OnManufacturerChanged();
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
