var dataTable;

function loadEmployeeLeaveDataTable() {
    dataTable = $('#tblAttendanceData').DataTable({
        "ajax": {
            "url": "/Admin/Attendance/GetAllModifiedTimeAttendance"
        },
        "columns": [
            { "data": "createdDate", "width": "25%" },
            { "data": "inTime", "width": "25%" },
            { "data": "outTime", "width": "25%" },
            { "data": "remarks", "width": "25%" }
        ]
    });
}

loadEmployeeLeaveDataTable();