// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById('add-education').addEventListener('click', function () {
    const container = document.getElementById('education-container');

    const newRow = document.createElement('div');
    newRow.classList.add('row', 'mt-3');
    newRow.innerHTML = `
                <!-- Education Status-->
                <div class="col-2">
                    <label class="form-label fw-bold">상태</label>
                    <select class="form-select" aria-label="Default select example">
                        <option selected>졸업여부</option>
                        <option value="1">대학교 졸업</option>
                        <option value="2">대학교 중퇴</option>
                        <option value="3">전문대 졸업</option>
                        <option value="4">전문대 중퇴</option>
                        <option value="5">고등학교 졸업</option>
                        <option value="6">고등학교 중퇴</option>
                        <option value="7">기타</option>
                    </select>
                </div>

                <!-- School name -->
                <div class="col-4">
                    <label class="form-label fw-bold">학교명</label>
                    <input type="text" class="form-control" />
                </div>

                <!-- Major -->
                <div class="col-3">
                    <label class="form-label fw-bold">전공</label>
                    <input type="text" class="form-control" />
                </div>
        `;

    container.appendChild(newRow);
});


document.getElementById('add-experience').addEventListener('click', function () {
    const container = document.getElementById('experience-container');

    const newRow = document.createElement('div');
    newRow.classList.add('row', 'mt-3');
    newRow.innerHTML = `
            <div class="col-1">
                <label class="form-label fw-bold">시작일</label>
                <input type="date" class="form-control" />
            </div>
            <div class="col-1">
                <label class="form-label fw-bold">종료일</label>
                <input type="date" class="form-control" />
            </div>
            <div class="col-3">
                <label class="form-label fw-bold">회사명</label>
                <input type="text" class="form-control" />
            </div>
            <div class="col-2">
                <label class="form-label fw-bold">부서</label>
                <input type="text" class="form-control" />
            </div>
            <div class="col-2">
                <label class="form-label fw-bold">직급</label>
                <input type="text" class="form-control" />
            </div>
        `;

    container.appendChild(newRow);
});