#Region "#usings"
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...
#End Region ' #usings;

Namespace TrendLines
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

#Region "#code"
        Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As EventArgs) Handles MyBase.Load
            ' Create an empty chart.
            Dim stockChart As New ChartControl()

            ' Create a stock series, add it to the chart and set its properties.
            Dim series1 As New Series("Series 1", ViewType.Stock)
            stockChart.Series.Add(series1)
            series1.ArgumentScaleType = ScaleType.DateTime
            series1.ValueScaleType = ScaleType.Numerical

            ' Add points to the series.
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 1), _
            New Object() {4.0, 5.0, 5.0, 4.85}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 2), _
            New Object() {6.05, 8.05, 6.05, 7.05}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 3), _
            New Object() {6.25, 8.25, 6.75, 7.15}))

            ' Create and customize a trendline, 
            Dim trendline1 As New TrendLine("A Trend")
            trendline1.Point1.Argument = New DateTime(1994, 3, 1)
            trendline1.Point1.ValueLevel = ValueLevel.High
            trendline1.Point2.Argument = New DateTime(1994, 3, 3)
            trendline1.Point2.ValueLevel = ValueLevel.High
            trendline1.ExtrapolateToInfinity = False
            trendline1.Color = Color.Red
            trendline1.LineStyle.DashStyle = DashStyle.Dash


            ' Cast the view type of the series to the Stock view.
            Dim myView As StockSeriesView = (CType(series1.View, StockSeriesView))

            ' Define the Y-axis range.
            myView.AxisY.Range.AlwaysShowZeroLevel = False

            ' Add the trendline to the series collection of indicators.
            myView.Indicators.Add(trendline1)

            ' Add the chart to the form.
            stockChart.Dock = DockStyle.Fill
            Me.Controls.Add(stockChart)
        End Sub
#End Region ' #code;

    End Class
End Namespace