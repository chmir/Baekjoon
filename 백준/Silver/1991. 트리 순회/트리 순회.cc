#include <iostream>
using namespace std;
int treeLen = 0;
char** tree;
char* findNode(char target){
    for (int i = 0; i < treeLen; i++)
        if (tree[i][0] == target) return tree[i];
    return new char[3]{ '.', '.', '.' };
}
void preorder(char* node){
    if (node[0] != '.') cout << node[0];
    if (node[1] != '.') preorder(findNode(node[1]));
    if (node[2] != '.') preorder(findNode(node[2]));
}
void inorder(char* node){
    if (node[1] != '.') inorder(findNode(node[1]));
    if (node[0] != '.') cout << node[0];
    if (node[2] != '.') inorder(findNode(node[2]));
}
void postorder(char* node){
    if (node[1] != '.') postorder(findNode(node[1]));
    if (node[2] != '.') postorder(findNode(node[2]));
    if (node[0] != '.') cout << node[0];
}

int main(){
    cin >> treeLen;
    tree = new char* [treeLen];
    for (int i = 0; i < treeLen; i++){tree[i] = new char[3];cin >> tree[i][0] >> tree[i][1] >> tree[i][2];}
    preorder(tree[0]);
    cout << endl;
    inorder(tree[0]);
    cout << endl;
    postorder(tree[0]);
}