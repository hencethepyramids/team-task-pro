// Write your JavaScript code. 

// Add hover effect to cards
document.querySelectorAll('.card').forEach(card => {
    card.addEventListener('mouseenter', function() {
        this.style.transform = 'translateY(-5px)';
        this.style.transition = 'transform 0.2s ease-in-out';
    });

    card.addEventListener('mouseleave', function() {
        this.style.transform = 'translateY(0)';
    });
});

// Initialize tooltips
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl);
});

// Auto-hide alerts after 5 seconds
document.querySelectorAll('.alert').forEach(alert => {
    setTimeout(() => {
        const bsAlert = new bootstrap.Alert(alert);
        bsAlert.close();
    }, 5000);
});

// Search functionality
const searchBar = document.querySelector('.search-bar');
if (searchBar) {
    let typingTimer;
    const doneTypingInterval = 500;

    searchBar.addEventListener('keyup', () => {
        clearTimeout(typingTimer);
        if (searchBar.value) {
            typingTimer = setTimeout(() => {
                // Implement search functionality here
                console.log('Searching for:', searchBar.value);
            }, doneTypingInterval);
        }
    });
}

// Add loading state to buttons
document.querySelectorAll('button[type="submit"]').forEach(button => {
    button.addEventListener('click', function() {
        const originalText = this.innerHTML;
        this.innerHTML = '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Loading...';
        this.disabled = true;

        // Reset after 2 seconds if the form doesn't submit
        setTimeout(() => {
            if (this.disabled) {
                this.innerHTML = originalText;
                this.disabled = false;
            }
        }, 2000);
    });
}); 