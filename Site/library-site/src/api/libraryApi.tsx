export const api = {
    getFeaturedBooks: async () => {
      return [
        { id: 1, title: "Book 1", author: "Author 1", rating: 4.5 },
        { id: 2, title: "Book 2", author: "Author 2", rating: 4.0 },
      ];
    },
    getBookDetails: async (id: number) => {
      return { id, title: "Book " + id, author: "Author " + id, description: "Lorem ipsum" };
    },
    login: async (username: string, password: string) => {
      return { success: true, token: "fakeToken123" };
    },
  };