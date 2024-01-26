import axios from "axios";

const apiUrl = "https://localhost:7161";

async function login(email: string, password: string): Promise<void> {
  try {
    const response = await axios.post(`${apiUrl}/login`, {
      email: email,
      password: password,
    });

    const token = response.data;

    localStorage.setItem("token", JSON.stringify(token));
    console.log("token: ", token);
  } catch (error) {
    console.error("Login error:", error);
    throw error;
  }
}

function getAuthToken(): string | null {
  const tokenString = localStorage.getItem("token");
  return tokenString ? JSON.parse(tokenString).token : null;
}

axios.interceptors.request.use((config) => {
  const token = AuthService.getAuthToken();
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
