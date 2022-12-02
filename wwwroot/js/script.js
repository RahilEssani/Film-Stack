var sidebarOpen = false;
var sidebar = document.getElementById("sidebar-new");
var sidebarCloseIcon = document.getElementById("sidebarIcon");

function toggleSidebar() {
    if (!sidebarOpen) {
        sidebar.classList.add("sidebar_responsive");
        sidebarOpen = true;
    }
}

function closeSidebar() {
    if (sidebarOpen) {
        sidebar.classList.remove("sidebar_responsive");
        sidebarOpen = false;
    }
}

function clck(e) {
    if (e.classList.contains('one')) {
        e.classList.add('active_menu_link');
        if (document.getElementsByClassName('three')[0].classList.contains('active_menu_link')) {
            document.getElementsByClassName('three')[0].classList.remove('active_menu_link');
        }
        else if (document.getElementsByClassName('two')[0]) {
            if (document.getElementsByClassName('two')[0].classList.contains('active_menu_link')) {
                document.getElementsByClassName('two')[0].classList.remove('active_menu_link');
            }
        }
        
        $.ajax({
            url: '/Account/Dashboard',
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html',
            success: function (result) {
                $('#main__').html(result);
            },
            error: function (xhr, status) {
                alert(status);
            }
        })
    }
    else if (e.classList.contains('two')) {
        e.classList.add('active_menu_link');
        if (document.getElementsByClassName('one')[0].classList.contains('active_menu_link')) {
            document.getElementsByClassName('one')[0].classList.remove('active_menu_link');
        }
        else if (document.getElementsByClassName('three')[0].classList.contains('active_menu_link')) {
            document.getElementsByClassName('three')[0].classList.remove('active_menu_link');
        }
        $.ajax({
            url: '/Account/PendingRequests',
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html',
            success: function (result) {
                $('#main__').html(result);
            },
            error: function (xhr, status) {
                alert(status);
            }
        })
    }
    else if (e.classList.contains('three')) {
        e.classList.add('active_menu_link');
        if (document.getElementsByClassName('one')[0].classList.contains('active_menu_link')) {
            document.getElementsByClassName('one')[0].classList.remove('active_menu_link');
        }
        else if (document.getElementsByClassName('two')[0]) {
            if (document.getElementsByClassName('two')[0].classList.contains('active_menu_link')) {
                document.getElementsByClassName('two')[0].classList.remove('active_menu_link');
            }
        }
        $.ajax({
            url: '/Account/Form',
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html',
            success: function (result) {
                $('#main__').html(result);
            },
            error: function (xhr, status) {
                alert(status);
            }
        })
    }

}

function form_submit(e) {
    //const file = $("#Image").files[0];
    var formData = new FormData();
    console.log($("#MovieID").val());
    formData.append("MovieID", $("#MovieID").val());
    formData.append("Title", $("#Title").val());
    formData.append("Year", $("#Year").val());
    formData.append("Crew", $("#Crew").val());
    formData.append("Rating", $("#Rating").val());
    formData.append("Genre", $("#Genre").val());
    formData.append('Image', $('input[type=file]')[0].files[0]);
    console.log("Hello");
    console.log(formData["Title"]);
    //formData.append('Image', file, 'chris1.jpg');
    $.ajax({
        url: "/Account/AddMovie",
        type: 'POST',
        cache: false,
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            $("#MovieID").val('');
            $("#Title").val('');
            $("#Year").val('');
            $("#Crew").val('');
            $("#Rating").val('');
            $("#Genre").val('');
            $('#fileInput').val('');
            alert(JSON.stringify(response));
        }
    });
}

function active_class(e) {
    console.log("hello");
    if (document.getElementsByClassName('active')[0]) {
        document.getElementsByClassName('active')[0].classList.remove('active');
    }
    e.target.classList.add('active');
}



function add_user(e) {
    var item = document.getElementsByClassName('active')[0];
    var data1 = item.getAttribute('data-id');
    console.log(data1);
    $.ajax({
        url: "/Account/AddUser",
        type: 'POST',
        dataType: 'JSON',
        data: { Udata: data1 },
        success: function (response) {
            e.remove();
        }
    });
}