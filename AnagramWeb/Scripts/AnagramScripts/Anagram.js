
$(document).ready(function () {
    $('#check_button').click(function (evt) {
        evt.preventDefault();

        $.ajax({
            url: 'http://localhost:56310/Home/Results?word=' + GetValueFromInput(),
            type: "GET",
            dataType: 'html',
            contentType: false,
            processData: false,
            success: function (dataResponse) {
                if ($('#anagram_results').length) {

                    $('#anagram_results').remove();
                    $('#page_content').append(dataResponse);
                }
                else {
                    $('#page_content').append(dataResponse);
                }
            },
            error: function (request, error) {
                alert("Request: " + request.responseText);
            }
        });
        //$("#results").load("/Views/Home/PartialViews", word: GetValueFromInput(), viewName: "Results");
    });

    var GetValueFromInput = function () {
        let originalString = $("#anagram_words").val();

        if (originalString === null || originalString === '' || typeof (originalString) === 'undefined') {
            alert("Error: Please, set any string");
        }
        else {
            return originalString;
        }
    };
});