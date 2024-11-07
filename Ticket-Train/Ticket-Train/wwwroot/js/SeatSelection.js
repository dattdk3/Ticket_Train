﻿document.addEventListener('DOMContentLoaded', function () {
    // Initialize variables
    let selectedSeats = new Set();
    const pricePerSeat = 995000; // Price in VND

    // Create seat grid
    function createSeatGrid() {
        const seatsGrid = document.querySelector('.seats-grid');
        for (let i = 1; i <= 64; i++) {
            const seat = document.createElement('div');
            seat.className = 'seat available';
            seat.dataset.seat = i;
            seat.textContent = i;

            // Mark some seats as occupied (for demo)
            if ([5, 12, 28, 35, 42, 50].includes(i)) {
                seat.className = 'seat occupied';
            }

            seat.addEventListener('click', handleSeatClick);
            seatsGrid.appendChild(seat);
        }
    }

    // Create sleeper compartments
    function createSleeperCompartments() {
        const compartments = document.querySelector('.compartments');
        const berthNumbers = [3, 4, 7, 8, 11, 12, 15, 16, 19, 20, 23, 24, 27, 28];

        berthNumbers.forEach(num => {
            const berth = document.createElement('div');
            berth.className = 'berth available';
            berth.dataset.berth = num;
            berth.textContent = num;

            // Mark some berths as occupied (for demo)
            if ([7, 15, 23].includes(num)) {
                berth.className = 'berth occupied';
            }

            berth.addEventListener('click', handleBerthClick);
            compartments.appendChild(berth);
        });
    }

    // Handle seat selection
    function handleSeatClick(event) {
        const seat = event.target;
        if (seat.classList.contains('occupied')) return;

        if (seat.classList.contains('selected')) {
            seat.classList.remove('selected');
            selectedSeats.delete(seat.dataset.seat);
        } else {
            seat.classList.add('selected');
            selectedSeats.add(seat.dataset.seat);
        }

        updateBookingSummary();
    }

    // Handle berth selection
    function handleBerthClick(event) {
        const berth = event.target;
        if (berth.classList.contains('occupied')) return;

        if (berth.classList.contains('selected')) {
            berth.classList.remove('selected');
            selectedSeats.delete('T2-' + berth.dataset.berth);
        } else {
            berth.classList.add('selected');
            selectedSeats.add('T2-' + berth.dataset.berth);
        }

        updateBookingSummary();
    }

    // Update booking summary
    function updateBookingSummary() {
        const selectedSeatsDisplay = document.getElementById('selectedSeatsDisplay');
        const totalPriceDisplay = document.getElementById('totalPrice');

        if (selectedSeats.size > 0) {
            selectedSeatsDisplay.textContent = Array.from(selectedSeats).join(', ');
            const total = selectedSeats.size * pricePerSeat;
            totalPriceDisplay.textContent = total.toLocaleString() + ' VND';
        } else {
            selectedSeatsDisplay.textContent = 'Chưa chọn ghế';
            totalPriceDisplay.textContent = '0 VND';
        }
    }

    // Handle proceed to booking
    document.getElementById('proceedToBooking').addEventListener('click', function () {
        if (selectedSeats.size === 0) {
            alert('Vui lòng chọn ít nhất một ghế trước khi tiếp tục');
            return;
        }
        // Save selected seats to sessionStorage for the next page
        sessionStorage.setItem('selectedSeats', JSON.stringify(Array.from(selectedSeats)));
        sessionStorage.setItem('totalPrice', document.getElementById('totalPrice').textContent);

        // Redirect to booking information page
        window.location.href = 'booking-info.html';
    });

    // Initialize the page
    createSeatGrid();
    createSleeperCompartments();
});