---
title: Homework 2
layout: default
---
## Homework 2
The second assignment asked us to create a dynamic webpage using HTML, CSS, Bootstrap, Javascript, and jQuery.
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW2.html).

## New Branch
The first step was making a new folder for HW2 and then creating a new branch named feature by using the following commands
```bash
        git checkout -b feature
```

After the new feature branch was created I made an index.html and styles.css and pushed to the repo using, </p>
```bash
      git push --set-upstream origin feature
```

## Layout
From there I worked on the basic layout I wanted for my dynamic webpage and came up with the wireframe mockup below.
![](HW2/mockup.PNG?raw=true)

## jQuery
Once I had the basic layout I started implementing the jQuery functions.
```bash
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
```

## Finished page
Once the functions were working I adjusted the pages appearance.
You can view the finished page [here](HW2/index.html).

## Merging back to master
Once I was happy with the pages appearance I merged the feature branch back in with master by using the following commands.

```bash
  git checkout master
  git merge feature
  git push origin master
```

## Issues
I did however run into some issues initially with merging. I kept getting
error: cannot stat 'HW2': Permission denied
It turned out I had to close everything related to the
files I wanted to merge back into master.
