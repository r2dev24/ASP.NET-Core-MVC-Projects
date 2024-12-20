// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function openProfilePopup() {
    const popup = window.open('/Auth/Profile', '_blank', 'width=800,height=600,resizable=yes,scrollbars=yes');
    if (!popup || popup.closed || typeof popup.closed == 'undefined') {
        alert('팝업이 차단되었습니다. 팝업 차단을 해제해주세요.');
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const contentInput = document.getElementById("contentInput");
    const fontSizeSelector = document.getElementById("fontSizeSelector");
    const fontColorPicker = document.getElementById("fontColorPicker");
    const boldButton = document.getElementById("boldButton");
    const italicButton = document.getElementById("italicButton");

    // 글자 색상 변경
    fontColorPicker.addEventListener("input", function () {
        contentInput.style.color = this.value;
    });

    // 글자 굵게 토글
    boldButton.addEventListener("click", function () {
        const isBold = contentInput.style.fontWeight === "bold";
        contentInput.style.fontWeight = isBold ? "normal" : "bold";
    });

    // 글자 기울임 토글
    italicButton.addEventListener("click", function () {
        const isItalic = contentInput.style.fontStyle === "italic";
        contentInput.style.fontStyle = isItalic ? "normal" : "italic";
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const customSelect = document.querySelector(".custom-select");
    const selectedOption = customSelect.querySelector(".selected-option");
    const dropdownOptions = customSelect.querySelector(".dropdown-options");

    selectedOption.addEventListener("click", function () {
        dropdownOptions.style.display = dropdownOptions.style.display === "block" ? "none" : "block";
    });

    dropdownOptions.querySelectorAll(".option").forEach(option => {
        option.addEventListener("click", function () {
            const value = this.getAttribute("data-value");
            selectedOption.textContent = this.textContent;
            dropdownOptions.style.display = "none";

            // Update textarea font size
            const contentInput = document.getElementById("contentInput");
            contentInput.style.fontSize = value;
        });
    });

    // Close dropdown when clicking outside
    document.addEventListener("click", function (event) {
        if (!customSelect.contains(event.target)) {
            dropdownOptions.style.display = "none";
        }
    });
});

