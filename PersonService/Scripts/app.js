var ViewModel = function () {

    var self = this;
    var personsUri = '/api/Person/';
    var titlesUri = '/api/Titles/';

    self.persons = ko.observableArray();
    self.error = ko.observable();

    self.detail = ko.observable();

    self.getPersonDetail = function (item) {
        ajaxHelper(personsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.titles = ko.observableArray(); // коллекция должностей сотрудников 

    self.newPerson = {
        LastName: ko.observable(),
        FirstName: ko.observable(),
        SecondName: ko.observable(),
        BirstDate: ko.observable(),
        Phone: ko.observable(),
        Email: ko.observable(),
        Title: ko.observable()
    }

    self.addPerson = function (formElement) {
        var person = {
            FirstName: self.newPerson.FirstName(),
            SecondName: self.newPerson.SecondName(),
            LastName: self.newPerson.LastName(),
            BirstDate: self.newPerson.BirstDate(),
            Phone: self.newPerson.Phone(),
            Email: self.newPerson.Email(),
            TitleId: self.newPerson.Title().Id
        };

        ajaxHelper(personsUri, 'POST', person).done(function (item) {
            self.persons.push(item);
        });
    }

    function ajaxHelper(uri, method, data) {

        self.error(''); // Clear error message 

        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllPersons() {
        ajaxHelper(personsUri, 'GET').done(function (data) {
            self.persons(data);
        });
    }

    function getTitless() {
        ajaxHelper(titlesUri, 'GET').done(function (data) {
            self.titles(data);
        });
    }

    getTitless();
    getAllPersons();
};

ko.applyBindings(new ViewModel()); 