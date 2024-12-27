import { useState } from "react";
import {
  Container,
  TextField,
  Button,
  Typography,
  Box,
  ToggleButton,
  ToggleButtonGroup,
} from "@mui/material";
import { useNavigate } from "react-router-dom"; // Import useNavigate

const AuthPage = () => {
  const [mode, setMode] = useState("login"); // Toggle between "login" and "register"
  const [formData, setFormData] = useState({ email: "", password: "" });
  const navigate = useNavigate(); // Initialize navigate function

  const handleToggle = (event: React.MouseEvent<HTMLElement>, newMode: string | null) => {
    if (newMode) {
      setMode(newMode);
      setFormData({ email: "", password: "" });
    }
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    alert(`${mode.toUpperCase()} Submitted: ${JSON.stringify(formData)}`);
    navigate("/dashboard"); // Redirect to dashboard
  };

  return (
    <Container maxWidth="xs" style={{ marginTop: "50px" }}>
      <Box textAlign="center" mb={2}>
        <ToggleButtonGroup
          value={mode}
          exclusive
          onChange={handleToggle}
          aria-label="login or register"
        >
          <ToggleButton value="login" aria-label="login">
            Login
          </ToggleButton>
          <ToggleButton value="register" aria-label="register">
            Register
          </ToggleButton>
        </ToggleButtonGroup>
      </Box>
      <Box textAlign="center" mb={2}>
        <Typography variant="h5">
          {mode === "login" ? "Login to Your Account" : "Create an Account"}
        </Typography>
      </Box>
      <form onSubmit={handleSubmit}>
        <TextField
          fullWidth
          margin="normal"
          label="Email"
          name="email"
          type="email"
          value={formData.email}
          onChange={handleInputChange}
        />
        <TextField
          fullWidth
          margin="normal"
          label="Password"
          name="password"
          type="password"
          value={formData.password}
          onChange={handleInputChange}
        />
        {mode === "register" && (
          <TextField
            fullWidth
            margin="normal"
            label="Confirm Password"
            name="confirmPassword"
            type="password"
            onChange={handleInputChange}
          />
        )}
        <Box textAlign="center" mt={2}>
          <Button type="submit" variant="contained" color="primary">
            {mode === "login" ? "Login" : "Register"}
          </Button>
        </Box>
      </form>
    </Container>
  );
};

export default AuthPage;
