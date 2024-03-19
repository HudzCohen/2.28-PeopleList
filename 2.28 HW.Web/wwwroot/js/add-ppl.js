
$(() => {
    let number = 1;

    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(`<div class="row" style="margin-bottom:10px;">
                    <div class="col-md-row">
                        <input class="form-control" type="text" name="people[${number}].firstname" placeholder="First Name" />
                    </div>
                    <div class="col-md-row mt-2" style="margin-bottom: 10px;">
                        <input class="form-control" type="text" name="people[${number}].lastname" placeholder="Last Name" />
                    </div>
                    <div class="col-md-row" style="margin-bottom: 10px;" >
                        <input class="form-control" type="text" name="people[${number}].age" placeholder="Age"/>
                    </div>
                </div>`);

        number++;
    });

});