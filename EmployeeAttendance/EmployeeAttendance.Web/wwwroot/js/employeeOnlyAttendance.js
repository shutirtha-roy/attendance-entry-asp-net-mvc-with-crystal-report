var dataTable;

function loadEmployeeLeaveDataTable() {
    dataTable = $('#tblEmployeeAttendanceData').DataTable({
        "ajax": {
            "url": "/Employee/EmployeeAttendance/GetModifiedEmployeeAttendance"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "createdDate", "width": "20%" },
            { "data": "inTime", "width": "20%" },
            { "data": "outTime", "width": "20%" },
            { "data": "remarks", "width": "20%" }
        ]
    });
}

loadEmployeeLeaveDataTable();