﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18034
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="DATA")>  _
Partial Public Class LINQ_ItemListDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.MassasrelliLabelPrinterLNQ.My.MySettings.Default.MassDATA_TCHPServerConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property vimItemLists() As System.Data.Linq.Table(Of vimItemList)
		Get
			Return Me.GetTable(Of vimItemList)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.vimItemList")>  _
Partial Public Class vimItemList
	
	Private _item_no As String
	
	Private _item_desc_1 As String
	
	Private _prod_cat As String
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_item_no", DbType:="Char(15) NOT NULL", CanBeNull:=false)>  _
	Public Property item_no() As String
		Get
			Return Me._item_no
		End Get
		Set
			If (String.Equals(Me._item_no, value) = false) Then
				Me._item_no = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_item_desc_1", DbType:="Char(30)")>  _
	Public Property item_desc_1() As String
		Get
			Return Me._item_desc_1
		End Get
		Set
			If (String.Equals(Me._item_desc_1, value) = false) Then
				Me._item_desc_1 = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_prod_cat", DbType:="Char(3)")>  _
	Public Property prod_cat() As String
		Get
			Return Me._prod_cat
		End Get
		Set
			If (String.Equals(Me._prod_cat, value) = false) Then
				Me._prod_cat = value
			End If
		End Set
	End Property
End Class
