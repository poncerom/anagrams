
$(document).ready(function () {
    $('#check_button').click(function (evt) {
        evt.preventDefault();
        let newValue = $("#anagram_words").val();

        if (typeof newValue !== 'undefined' && newValue !== null && newValue !== "") {

            $.ajax({
                url: 'http://localhost:56310/Home/Results?word=' + newValue,
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
        }
        else {
            alert("Error: Please, set any string");
        }
    });
});