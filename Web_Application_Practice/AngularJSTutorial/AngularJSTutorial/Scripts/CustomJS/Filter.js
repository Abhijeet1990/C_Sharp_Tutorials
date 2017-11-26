/// <reference path="Script.js" />

myApp.filter("gender", function () { // filter is something that takes func and return function
    return function(gender){
        switch (gender) {
            case 1:
                return "Male";
            case 2:
                return "Female";
        }
    }
})