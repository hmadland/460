
function addListItem() {
  var text = $("#todoInput").val();
  if(text != ""){
  $("#todo").append('<li class="BoldB">' + '<button class="delete">' + text +'</button></li>');
  $("#todoInput").val('');
}}

function deleteItem() {
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
