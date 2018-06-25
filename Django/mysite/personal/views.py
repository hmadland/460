from django.shortcuts import render

def index(request):
    return render(request, 'personal/home.html')


def contact(request):
    return render(request, 'personal/basic.html', {'content': ['If you would like to contact me, please email me', 'hkmadland23@gmail.com']})


def blog(request):
    return render(request, 'personal/blog.html')
