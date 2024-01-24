// LoginPage.js
import React from 'react';
import LoginForm from '../components/LoginForm';

const LoginPage = () => {
  // Funkcija koja će biti pozvana kada se podaci pošalju
  const handleLogin = (data) => {
    // Ovde možete dodati logiku za prijavu (npr. poziv API-ja)
    console.log('Prijavljeni podaci:', data);
  };

  return (
    <div>
      <h2>Login Page</h2>
      <LoginForm onSubmit={handleLogin} />
    </div>
  );
};

export default LoginPage;
