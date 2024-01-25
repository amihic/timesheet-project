import axios from "axios";

const apiUrl = 'https://localhost:7161';

async function login(email: string, password: string): Promise<void> {
  try {
    const response = await axios.post(
      `${apiUrl}/login`,
      {
        email: email,
        password: password,
      }
    );

    const token = response.data;

    localStorage.setItem("token", JSON.stringify(token));
    console.log("token: ", token);
  } catch (error) {
    console.error("Login error:", error);
    throw error;
  }
}

function getAuthToken(): Promise<string | null> {
    return new Promise((resolve) => {
        const tokenString = localStorage.getItem("token");
        resolve(tokenString ? JSON.parse(tokenString) : null);
      });
}

axios.interceptors.request.use((config) => {

  const token = getAuthToken();
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});


const AuthService = {
  login,
  getAuthToken,
};

export default AuthService;
