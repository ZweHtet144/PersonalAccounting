$(function () {
    $("#CityId").change(function () {

        $.ajax({
            url: '/township/GetTownshipsWithCityId',
            data: { cityId: $("#CityId").val() },
            type: 'GET',
            contentType: 'application/json',
            success: function (townships) {
                console.log(townships);
                $("#TownshipId").empty();
                $("#TownshipId").append("<option value=''>Select Township</option>");
                for (i = 0; i < townships.length; i++) {
                    $("#TownshipId").append("<option value=" + townships[i].Id + ">" + townships[i].Name + "</option>");
                }
                $("#TownshipId").prop("disabled", false);
            }

        });
    });

    //more function here
})