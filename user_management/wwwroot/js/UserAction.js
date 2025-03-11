const API_BASE_URL = "https://localhost:5001/api/User";

// Function to create a new user
async function createUser(userData) {
    try {
        const response = await fetch(`${API_BASE_URL}/Create`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(userData)
        });
        return await response.json();
    } catch (error) {
        console.error("Error creating user:", error);
    }
}

// Function to get all users
async function getAllUsers() {
    try {
        const response = await fetch(`${API_BASE_URL}/All`);
        return await response.json();
    } catch (error) {
        console.error("Error fetching users:", error);
    }
}

// Function to get user by ID
async function getUserById(userId) {
    try {
        const response = await fetch(`${API_BASE_URL}/${userId}`);
        return await response.json();
    } catch (error) {
        console.error("Error fetching user:", error);
    }
}

// Function to update a user
async function updateUser(userId, userData) {
    try {
        const response = await fetch(`${API_BASE_URL}/Update/${userId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(userData)
        });
        return await response.json();
    } catch (error) {
        console.error("Error updating user:", error);
    }
}

// Function to delete a user by ID
async function deleteUser(userId) {
    try {
        const response = await fetch(`${API_BASE_URL}/Delete/${userId}`, {
            method: "DELETE"
        });
        return await response.json();
    } catch (error) {
        console.error("Error deleting user:", error);
    }
}

// Export all functions
export { createUser, getAllUsers, getUserById, updateUser, deleteUser };