#r "System.Data.OracleClient"

open System
open System.Data
open System.Data.OracleClient

// Connect to the database
let connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=host)(PORT=port)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=service_name)));User Id=user_name;Password=password;"
let connection = new OracleConnection(connectionString)
connection.Open()

// Create a command
let command = new OracleCommand("SELECT * FROM your_table", connection)

// Execute the command and get the reader
let reader = command.ExecuteReader()

// Loop through the results and print them
while reader.Read() do
    for i in 0 .. reader.FieldCount - 1 do
        printfn "%s: %s" reader.GetName(i) reader.[GetValue(i)]
    printfn ""

// Close the reader and connection
reader.Close()
connection.Close()
