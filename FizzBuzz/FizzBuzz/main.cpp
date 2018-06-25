#include <iostream>

using namespace std;

int main()
{
    int i = 0;
    cout << "Let's Playe FizzBuzz!" << endl<< "Enter an Integer!" << endl;
    cin >> i;
    if(i%15==0){
        cout << "FizzBuzz!" << endl;
    }
    else if(i%3 == 0){
        cout << "Fizz" << endl;
    }
    else if (i%5==0){
        cout << "Buzz"<< endl;
    }
    else{
        cout << i << endl;
    }
    return 0;
}
