// Create an array of objects representing the data for your table
var tableData = [
    { name: "John Doe", age: 30, city: "New York" },
    { name: "Jane Smith", age: 25, city: "Los Angeles" },
    { name: "Mike Johnson", age: 35, city: "Chicago" }
];

// Function to generate the HTML table
function generateTable(data) {
    var html = "<table border='1'>";

    // Table header
    html += "<tr>";
    for (var key in data[0]) {
        html += "<th>" + key + "</th>";
    }
    html += "</tr>";

    // Table body
    data.forEach(function (item) {
        html += "<tr>";
        for (var key in item) {
            html += "<td>" + item[key] + "</td>";
        }
        html += "</tr>";
    });

    html += "</table>";
    return html;
}

// Display the table in the HTML document
document.getElementById("table-container").innerHTML = generateTable(tableData);
