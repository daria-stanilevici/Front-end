// 1. There are 2 multiline elements of the <textarea> form and a button, when clicked, the values of the components are swapped.
const swapText = () => {
    const firstTextArea = document.getElementById("first-area");
    const secondTextArea = document.getElementById("second-area");

    [firstTextArea.value, secondTextArea.value] = [
        secondTextArea.value,
        firstTextArea.value,
    ];
};

// 2. Paragraphs with numbers are given. By clicking on a paragraph, the square of the number it contains should appear in it, but only by the first click.
const first_multiply = (number) => {
    return number ** 2;
};
const second_multiply = (number) => {
    return number ** 3;
};
const third_multiply = (number) => {
    return number ** 4;
};
const paragraphs = document.querySelectorAll(".numbers p");
paragraphs.forEach((element) => {
    element.addEventListener(
        "click",
        (event) => {
            event.target.textContent = first_multiply(
                parseInt(event.target.textContent)
            );
        },
        { once: true }
    );
});
const handler = (event) => {
    let count = parseInt(event.target.dataset.counter);
    // console.log(event.target.dataset.counter);
    if (event.target.dataset.counter === "1") {
        event.target.textContent = first_multiply(parseInt(event.target.textContent));
        event.target.dataset.counter = count + 1;
    } else if (event.target.dataset.counter === "2") {
        event.target.textContent = second_multiply(parseInt(event.target.textContent));
        event.target.dataset.counter = count + 1;
    } else if (event.target.dataset.counter === "3") {
        event.target.textContent = third_multiply(parseInt(event.target.textContent));
        event.target.dataset.counter = count + 1;
    }
    if (count === 4) this.removeEventListener("click", handler);
};

// 3. Paragraphs with numbers are given. On the first click on a paragraph, the square of the number it contains should appear in it. On the second click - cube. On the third click - the fourth degree.
const multiple_clicks = document.querySelectorAll(".multiple_clicks p");
multiple_clicks.forEach((element) => {
    element.addEventListener("click", handler);
});

// 4. Inputs are given. Make sure that all inputs check their contents for the correct number of characters after losing focus. How many characters should be in the input is specified in the data-length property. If the correct amount is entered, then the input border becomes green, if the wrong one is red.
let el = document.querySelectorAll('.characters input');
for (let i = 0; i < el.length; i++) {
    el[i].addEventListener('blur', color);
}
function color() {
    let length = this.dataset.length;
    let data_length = this.value.length;
    if(length === data_length){
        this.style.borderColor = 'green';
    } else {
        this.style.borderColor = 'red';
    }
}
// 5. Divas are given. On the first click on each diva, it is painted with a red background, on the second it is painted back, and so on, each click alternates the background. Make it so that there are two functions: one paints red, the other green, and they replace each other through removeEventListener.
let elems = document.querySelectorAll('.color div');
for (let i = 0; i < elems.length; i++) {
    elems[i].addEventListener('click', colorRed);
}
function colorRed() {
    this.style.background = 'red';
    this.removeEventListener('click', colorRed);
    this.addEventListener('click', colorGreen);
}
function colorGreen() {
    this.style.background = 'green';
    this.removeEventListener('click', colorGreen);
    this.addEventListener('click', colorRed);
}

// 6. 3 selections are given: with the day, with the month and the year. Make it so that the incorrect date cannot be selected
const year = document.getElementById("year");
const month = document.getElementById("month");
const day = document.getElementById("day");
const day_arr = document.querySelectorAll("#day option");
const date = document.getElementById("date");
const days = Array.from(day_arr);
date.textContent = `${day.value} / / ${month.value} / / ${year.value}`;
month.addEventListener("change", (event) => {
    days.map((option) => (option.style.display = "block"));
    if (event.target.value === "2") {
        days.map((option) => {
            if (option.value > 28) option.style.display = "none";
        });
    } else if (event.target.value === "4") {
        days.map((option) => {
            if (option.value > 30) option.style.display = "none";
        });
    } else if (event.target.value === "6") {
        days.map((option) => {
            if (option.value > 30) option.style.display = "none";
        });
    } else if (event.target.value === "9") {
        days.map((option) => {
            if (option.value > 30) option.style.display = "none";
        });
    } else if (event.target.value === "11") {
        days.map((option) => {
            if (option.value > 30) option.style.display = "none";
        });
    }
    date.textContent = `${day.value} / ${event.target.value}/${year.value}`;
});

day.addEventListener("change", (event) => {
    date.textContent = `${event.target.value}/${month.value}/${year.value}`;
});
year.addEventListener("change", (event) => {
    date.textContent = `${day.value}/${month.value}/${event.target.value}`;
});