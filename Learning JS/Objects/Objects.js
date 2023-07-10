/* 1. The object {js:'test', jq: 'hello', css: 'world'} is given. Get an array of its keys*/
let user = {
js: "test", 
jq: "hello", 
css: "world"
};  
alert(Object.keys(user));


/* 2. A string of characters S is given, consisting of a maximum of 250 characters. 
Write a program that checks whether the string S is a palindrome. 
Examples of palindromes: 'COJOC’ ‘' CAZAC’ ‘ 'POTOP’,' ROTOR’.*/
let Check = prompt("Enter a word: ", "TENET");
alert(Check.slice(0, Math.ceil(Check.length / 2)) == Check.slice(Check.length / 2).split('').reverse().join('') ?
"This is a palindrome!" : "This is not a palindrome");


/* 3. A string of characters is given. 
Any sequence of digits is considered a word of the text. Delete all symmetric words (palindromes). 
Words from a single digit are not considered palindromes.*/
let Str = prompt("Enter the line: ", `1441 476 399992 1233 1111`);
let MyStr = Str;
function isPalindrom(str) {
str = str.split(',')[0];
if(Number.isInteger(+str)) {
return str.slice(0, Math.ceil(str.length / 2)) == str.slice(str.length / 2).split('').reverse().join('');
}
return false;
}
let strArr = Str.split(' ');
strArr.forEach((item, index) => {
if (isPalindrom(item)) {
strArr.splice(index, 1);
}
});
Str = strArr.join(' ');
alert("Your line: " + MyStr + "\r\nProcessed string: " + Str);


/* 4. A string of S characters is given. 
Write a program that counts how many times the sequence of characters 'cert' is included in S.*/
let Str = prompt("Enter the text you want to check for \"cert\":", 
"But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of certain selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.");
let num = 0;
while(Str.includes("cert")) {
Str = Str.substring(Str.indexOf("cert") + 4);
num++;
}
alert("The number of \ "cert\" sequences in a string - " + num);


/* 5. A string of characters is given. 
Any sequence of letters and numbers is considered a word of the text. 
Remove every odd word of odd length from it.*/
let Str = prompt("Enter the line in which you want to delete odd - numbered lines of odd length:", 
"But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of certain selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.");
let MyStr = Str;
let strArr = Str.split(" ");
let newArr = [];
strArr.forEach((item, index) => {
if(!(item.length % 2 == 1 && (index + 1) % 2 == 1)) {
newArr.push(item);
}
});
Str = newArr.join(" ");
alert("Your line: " + MyStr + "\r\nProcessed string: " + Str);


/* 6. Given a one-dimensional array of integers A[1..n]. Write a program that will write to the array B[1..n] first 
in descending order all the negative elements of the array A, and then in ascending order all the positive elements 
of the array A. For example, for A = (4, -8, 7, -6, 0, -7, 5), we get B = (-6, -7, -8, 0, 4, 5, 7).*/
let A = [4, -8, 7, -6, 0, -7, 5];
alert("Your array: " + A);
let B = A.sort((x, y) => // forming a sorting
(x < 0 && y < 0) ? -x + y : x - y);
alert("Sorted array: " + B);


/* 7. A string of T characters is given. Write a program that will triple each space. */
let T = prompt("Enter the line where you want to multiply by 3 spaces: ", 
	"But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of certain selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains.");
T = T.split(" ").join("   "); // There are 3 spaces in the join!!
alert(T);


/* 8. A string of characters S is given, which is an arithmetic expression with a single operation sign ( + , -, * or /).
Write a program that will calculate the value of the expression. For example, for S = ' 234+153’, we get 387.*/
let Str = prompt("Enter an issue you want to solve:", "234 + 153");
let issue;
Str.split('').forEach((element, index) => {
if (!Number.isInteger(+element)) {
issue = element;
}
});
let arr = Str.split(issue);
let Decision;
switch (issue) {
case "+" : Decision = +arr[0] + +arr[1]
case "-" : Decision = arr[0] - arr[1]
case "*" : Decision = arr[0] * arr[1]
case "/" : Decision = arr[0] / arr[1]
default:
alert("Something wrong!");
}
alert("Decision: " + Decision);