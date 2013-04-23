
function TaskViewModel(task) {
    var self = this;

    self.id = task.id;
    self.description = task.description;
    self.date = task.date;
    self.isCompleted = task.isCompleted;
    self.userName = task.userName;
}

function ToDoViewModel() {
    var self = this;

    self.tasks = ko.observableArray();
    self.taskToAdd = ko.observable("");

    self.getAll = function () {
        self.tasks.removeAll();

        $.ajax({
            url: "api/ToDo/",
            accepts: "application/json",
            cache: false,
            statusCode:
                {
                    200: function (data) {
                        $.each(data, function (key, value) {
                            self.tasks.push(new TaskViewModel(value));
                        });
                    },
                    401: function () {
                        window.location = "/Account/Login/";
                    }
                }
        });
    };

    self.post = function () {
        var task = JSON.stringify({
            id: -1,
            description: self.taskToAdd(),
            date: Date.now(),
            isCompleted: false,
            userName: ""
        });

        $.ajax({
            url: "api/ToDo/",
            accepts: "application/json",
            cache: false,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: task,
            success: self.getAll
        }).fail(function (xhr, textStatus, err) {
            alert(err);
        });

        self.taskToAdd("");
    };

    self.update = function (task) {
        task.isCompleted = true;

        $.ajax({
            url: "api/ToDo/" + task.id,
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            type: "PUT",
            cache: false,
            data: ko.toJSON(task),
            success: self.getAll
        }).fail(function (xhr, textStatus, err) {
            alert(err);
        });

        return true;
    };

    self.delete = function (task) {
        $.ajax({
            url: "api/ToDo/" + task.id,
            type: "DELETE",
            cache: false,
            success: self.getAll
        }).fail( function ( xhr, textStatus, err ) {
            alert(err);
        });
    };

    self.sort = function () {
        self.tasks.sort(self.sortFunction);
    };

    self.sortFunction = function (a, b) {
        return a.isCompleted < b.isCompleted ? -1 : 1;
    };
}
