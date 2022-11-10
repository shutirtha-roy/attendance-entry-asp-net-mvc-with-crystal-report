var dataTable;

function loadEmployeeLeaveDataTable() {
    dataTable = $('#tblAttendanceData').DataTable({
        "ajax": {
            "url": "/Admin/Attendance/GetAllModifiedTimeAttendance"
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