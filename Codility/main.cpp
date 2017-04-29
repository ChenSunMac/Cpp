/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   main.cpp
 * Author: Sun
 *
 * Created on 2017年4月28日, 下午10:13
 */

#include <iostream>
#include <vector>

using namespace std;



class Solution { public:
    
// Frog-Jmp : jump from X to Y or somewhere larger than Y;
// The frog jump up D everytime,  solve how many it jums in total
int Frog_jump(int X, int Y, int D) {  
    // write your code here...  
    return (X >= Y)?0:((Y - X + D - 1) / D);  
}  

// Perm-Missing-Elem: In a array with Length N, All elements are different;
// Find the missing numbre with O(n) time
int Missing_elem(vector<int> &A) {
    int n = A.size(), i;  
    long long r = n + 1;  
    for (i = 0; i < n; ++i) {  
        r += (i + 1) - A[i];  
    }  
    return r; 
}
// Tape-Equilibrium: In a array with Length N, with 0 < p < N;
// Find the smallest difference =  |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|
// O(n) time

int Tape_Equilibrium(vector<int> &A) {  
    // write your code here...  
    int n = A.size(), sum, r, i, t;  
    for (i = sum = 0; i < n; ++i) {  
        sum += A[i];  
    }  
    r = abs(sum - A[0] - A[0]);  
    for (i = 2, t = A[0]; i < n; ++i) {  
        t += A[i - 1];  
        r = min(r, abs(sum - t - t));  
    }  
    return r;  
}  



};

/*
 * 
 */
int main(int argc, char* argv[]) {
    int x = 5, y = 10;
    int d = 3;
    int z;
    Solution solution;
    z = solution.Frog_jump(x,y,d) ;
    cout <<  z << endl;
    
    vector<int> input;
    input.push_back(1);        //initialize the vector
    input.push_back(2);
    input.push_back(5);
    input.push_back(4);
    //[1, 2, 5, 4]
    z = solution.Missing_elem(input) ;
    cout <<  z << endl; 

    return 0;
}

