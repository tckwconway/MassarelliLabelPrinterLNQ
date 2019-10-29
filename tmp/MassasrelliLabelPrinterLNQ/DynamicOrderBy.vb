Imports System.Linq
Imports System.Linq.Expressions


Public NotInheritable Class DynamicOrderBy
    Private Sub New()
    End Sub

    '<System.Runtime.CompilerServices.Extension()> _
    Public Shared Function OrderBy(Of TEntity As Class)(source As IQueryable(Of TEntity), orderByProperty As String, desc As Boolean) As IQueryable(Of TEntity)

        Dim command As String = If(desc, "OrderByDescending", "OrderBy")

        Dim type = GetType(TEntity)

        Dim [property] = type.GetProperty(orderByProperty)

        Dim parameter = Expression.Parameter(type, "p")

        Dim propertyAccess = Expression.MakeMemberAccess(parameter, [property])

        Dim orderByExpression = Expression.Lambda(propertyAccess, parameter)


        Dim resultExpression = Expression.[Call](GetType(Queryable), command, New Type() {type, [property].PropertyType}, source.Expression, Expression.Quote(orderByExpression))

        Return source.Provider.CreateQuery(Of TEntity)(resultExpression)

    End Function

End Class


