import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { getMovies, deleteMovie } from '../redux/actions/movieActions';
import CardContent from '@material-ui/core/CardContent';
import MovieCard from './MovieCard';
import './styles/HomePage.css';
const MovieList = ({
  getMovies,
  movie,
  isAuthenticated,
  deleteMoviezz
}) => {
  useEffect(() => {
    getMovies();
  }, [getMovies]);

  const handleDelete = (id) => {
    deleteMovie(id);
  };

  const { movies } = movie;
  return (
    
        <div className="movie-container">
          {movies.length>0 && movies.map((movieMap) => 
            <MovieCard movie={movieMap} key={movieMap.Id} />
          )}
        </div>
    
  );
};

const mapStateToProps = (state) => ({
  movie: state.movie,
  isAuthenticated: state.auth.isAuthenticated
});

export default connect(mapStateToProps, { getMovies, deleteMovie })(MovieList);