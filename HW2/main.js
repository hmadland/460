function addListItem() {
  var text = $("#todoInput").val();
  if(text != ""){
  $("#todo").append('<li class="BoldB">' + '<button class="delete">' + text +'</button></li>');
  //$("#todo").append('<li class="BoldB">' + '<button class="delete"> Done </button>' + "  " + text + '</li>');
  $("#todoInput").val('');
}
}
function deleteItem() {
//  var text = $(this).parent().clone().html();

//  $("#done").append('<li>' + text + '</li>');
  $(this).parent().fadeOut().remov();
}

$("#todoInput").keypress(function(event) {
    if (event.which == 13) {
        event.preventDefault();
        $("form").submit();
    }
});


$(function() {
  $("#add").on('click', addListItem);
  $(document).on( 'click', '.delete', deleteItem );
});
