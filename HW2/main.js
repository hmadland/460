//funcions
///<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

function addTask() {

   var itemTask = document.getElementById('todoInput').value
   var textTask = document.createTextNode(itemTask)
   var newItem = document.createElement('li')

   newItem.appendChild(textTask)
   document.getElementById('totalTime').appendChild(newItem)
}

function totalTime(){
   var total = parseInt(document.getElementById('totalList').value)
   var temp = parseInt(document.getElementById('timeInput').value)

   var newItem = document.createElement('li')

   if (isNaN(total)===true){ total = 0}
   var answere = total + temp
   var answereList = document.createTextNode(answere)
   newItem.appendChild(answereList)
   document.getElementById('totalList').appendChild(answerList)
   document.getElementById('total').innerHTML =answere
}
