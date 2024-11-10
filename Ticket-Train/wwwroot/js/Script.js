document.addEventListener('DOMContentLoaded', function () {
    // Form elements
    const searchForm = document.getElementById('ticketSearchForm');
    const tripTypeInputs = document.querySelectorAll('input[name="tripType"]');
    const returnDateDiv = document.querySelector('.return-date');
    const departDateInput = document.getElementById('departDate');
    const returnDateInput = document.getElementById('returnDate');
    const searchResults = document.getElementById('searchResults');

    // Set minimum date for departure and return
    const today = new Date().toISOString().split('T')[0];
    departDateInput.min = today;
    returnDateInput.min = today;

    // Handle trip type selection
    tripTypeInputs.forEach(input => {
        input.addEventListener('change', function () {
            if (this.value === 'roundTrip') {
                returnDateDiv.classList.remove('hidden');
                returnDateInput.required = true;
            } else {
                returnDateDiv.classList.add('hidden');
                returnDateInput.required = false;
            }
        });
    });

    // Handle departure date change
    departDateInput.addEventListener('change', function () {
        returnDateInput.min = this.value;
        if (returnDateInput.value && returnDateInput.value < this.value) {
            returnDateInput.value = this.value;
        }
    });

    // Handle form submission
    searchForm.addEventListener('submit', function (e) {
        e.preventDefault();

        // Get form values
        const formData = {
            departure: document.getElementById('departure').value,
            arrival: document.getElementById('arrival').value,
            tripType: document.querySelector('input[name="tripType"]:checked').value,
            departDate: departDateInput.value,
            returnDate: returnDateInput.value
        };

        // Simulate API call and show results
        searchTrains(formData);
    });

    // Function to search trains (simulation)
    function searchTrains(formData) {
        // Simulate loading state
        searchResults.innerHTML = '<p class="loading">Đang tìm kiếm vé...</p>';
        searchResults.classList.remove('hidden');

        // Simulate API delay
        setTimeout(() => {
            // Mock data for demonstration
            const mockTrains = [
                {
                    trainNo: 'SE8',
                    departure: formData.departure,
                    arrival: formData.arrival,
                    departTime: '06:00',
                    arrivalTime: '19:12',
                    price: '995,000',
                    seats: '23'
                },
                {
                    trainNo: 'SE6',
                    departure: formData.departure,
                    arrival: formData.arrival,
                    departTime: '15:00',
                    arrivalTime: '04:35',
                    price: '1,552,000',
                    seats: '16'
                }
            ];

            displaySearchResults(mockTrains);
        }, 1000);
    }

    // Function to display search results
    function displaySearchResults(trains) {
        let html = '<h3>Kết quả tìm kiếm</h3>';

        trains.forEach(train => {
            html += `
                <div class="train-result">
                    <div class="train-info">
                        <h4>Tàu ${train.trainNo}</h4>
                        <p>Khởi hành: ${train.departTime}</p>
                        <p>Đến nơi: ${train.arrivalTime}</p>
                        <p>Số ghế trống: ${train.seats}</p>
                        <p class="price">Giá: ${train.price} VND</p>
                    </div>
                    <button class="book-btn" onclick="bookTicket('${train.trainNo}')">
                        Đặt vé
                    </button>
                </div>
            `;
        });

        searchResults.innerHTML = html;
    }

    // Global function for booking (will be called from button click)
    window.bookTicket = function (trainNo) {
        alert(`Bắt đầu quy trình đặt vé cho tàu ${trainNo}`);
        // Add booking logic here
    };
});