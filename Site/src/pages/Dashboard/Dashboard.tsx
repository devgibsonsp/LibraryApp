import React, { useState } from "react";
import {
  AppBar,
  Toolbar,
  Typography,
  Box,
  Grid,
  Button,
  Card,
  CardContent,
  CardMedia,
  TextField,
  MenuItem,
} from "@mui/material";

const Dashboard = () => {
  // Placeholder data based on the Book model
  const [books, setBooks] = useState([
    {
      id: 1,
      title: "Book Title 1",
      author: "Author 1",
      description: "A fascinating description of Book Title 1.",
      coverImage: "https://via.placeholder.com/150",
      publisher: "Publisher 1",
      publicationDate: new Date("2021-01-01"),
      category: "Fiction",
      isbn: "123-456-789",
      pageCount: 320,
      isAvailable: true,
      averageRating: 4.5,
    },
    {
      id: 2,
      title: "Book Title 2",
      author: "Author 2",
      description: "A captivating description of Book Title 2.",
      coverImage: "https://via.placeholder.com/150",
      publisher: "Publisher 2",
      publicationDate: new Date("2020-05-15"),
      category: "Non-Fiction",
      isbn: "987-654-321",
      pageCount: 250,
      isAvailable: false,
      averageRating: 3.8,
    },
  ]);

  // State for search and sorting
  const [searchTerm, setSearchTerm] = useState("");
  const [sortBy, setSortBy] = useState("title");

  // Handler for search input
  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(e.target.value);
  };

  // Handler for sorting
  const handleSortChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSortBy(e.target.value);
  };

  // Filtered and sorted books
  const filteredBooks = books
    .filter((book) =>
      book.title.toLowerCase().includes(searchTerm.toLowerCase())
    )
    .sort((a, b) => {
      if (sortBy === "title") return a.title.localeCompare(b.title);
      if (sortBy === "author") return a.author.localeCompare(b.author);
      if (sortBy === "availability") return (a.isAvailable === b.isAvailable) ? 0 : a.isAvailable ? -1 : 1;
      return 0;
    });

  return (
    <Box>
      {/* AppBar for Navigation */}
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" style={{ flexGrow: 1 }}>
            Library Dashboard
          </Typography>
          <Button color="inherit">Log Out</Button>
        </Toolbar>
      </AppBar>

      <Box p={3}>
        {/* Search and Sort Section */}
        <Grid container spacing={2} alignItems="center">
          <Grid item xs={12} sm={6}>
            <TextField
              fullWidth
              label="Search for Books"
              variant="outlined"
              value={searchTerm}
              onChange={handleSearch}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              select
              fullWidth
              label="Sort By"
              variant="outlined"
              value={sortBy}
              onChange={handleSortChange}
            >
              <MenuItem value="title">Title</MenuItem>
              <MenuItem value="author">Author</MenuItem>
              <MenuItem value="availability">Availability</MenuItem>
            </TextField>
          </Grid>
        </Grid>

        {/* Featured Books Section */}
        <Box mt={4}>
          <Typography variant="h5" gutterBottom>
            Featured Books
          </Typography>
          <Grid container spacing={3}>
            {filteredBooks.map((book) => (
              <Grid item xs={12} sm={6} md={4} key={book.id}>
                <Card>
                  <CardMedia
                    component="img"
                    height="200"
                    image={book.coverImage}
                    alt={book.title}
                  />
                  <CardContent>
                    <Typography variant="h6">{book.title}</Typography>
                    <Typography variant="subtitle2" gutterBottom>
                      By {book.author}
                    </Typography>
                    <Typography variant="body2">{book.description}</Typography>
                    <Typography variant="caption">
                      Publisher: {book.publisher}
                    </Typography>
                    <br />
                    <Typography variant="caption">
                      Published: {book.publicationDate.toDateString()}
                    </Typography>
                    <br />
                    <Typography variant="caption">
                      Category: {book.category}
                    </Typography>
                    <br />
                    <Typography variant="caption">
                      ISBN: {book.isbn}
                    </Typography>
                    <br />
                    <Typography variant="caption">
                      Pages: {book.pageCount}
                    </Typography>
                    <br />
                    <Typography variant="caption">
                      Average Rating: {book.averageRating} ⭐
                    </Typography>
                    <br />
                    <Typography variant="caption">
                      {book.isAvailable ? "Available" : "Checked Out"}
                    </Typography>
                    <Box mt={2}>
                      <Button
                        variant="contained"
                        size="small"
                        color="primary"
                        disabled={!book.isAvailable}
                      >
                        {book.isAvailable ? "Check Out" : "Unavailable"}
                      </Button>
                    </Box>
                  </CardContent>
                </Card>
              </Grid>
            ))}
          </Grid>
        </Box>
      </Box>
    </Box>
  );
};

export default Dashboard;
