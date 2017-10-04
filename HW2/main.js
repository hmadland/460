//funcions
//<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  var lists = {
      todo: document.getElementById('todo'),
      done: document.getElementById('done')
    };


function addTask() {
   var item = document.getElementById('todoInput').value;
   var space = document.createTextNode('  ');
   var newItem = document.createElement('li');

   var checkbox = document.createElement('input');
   checkbox.type = "checkbox";
   checkbox.addEventListener('click', onCheck);
   var label = document.createElement('label');
   label.htmlFor = "id";
   label.appendChild(document.createTextNode(item));

   newItem.appendChild(label);
   newItem.appendChild(space);
   newItem.appendChild(checkbox);
   document.getElementById('todo').appendChild(newItem);
};

function onCheck(event){
  var task = event.target.parentElement;
  var list = task.parentElement.id;
  lists[list === 'done' ? 'todo' : 'done'].appendChild(task);
  this.checked = false;
  input.focus();
  };
