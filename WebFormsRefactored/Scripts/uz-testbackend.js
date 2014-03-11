// Using $(document).ready() is better practice than window.onload or WebForms body onLoad. Removing JavaScript from Html is also good. But I am not a JavaScript expert.
$(function () {
    var myJSONTasksConfig = { "tasksConfiguration": { "limit": "40", "total": "50" } };

    // write your code to show the message according to the specification inside the function checkShowWarning that gets called from the onload on the master page
    function checkShowWarning() {
        if ($.isEmptyObject(myJSONTasksConfig)) return;
        if (myJSONTasksConfig.tasksConfiguration.total > myJSONTasksConfig.tasksConfiguration.limit) {
            $('#warn-limit').removeClass('uz-hidden');
        }
    }

    checkShowWarning();
});