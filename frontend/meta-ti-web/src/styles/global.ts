import { createGlobalStyle } from 'styled-components';

export default createGlobalStyle`
  *{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }

  *:focus {
    outline: none;
  }

  body{
    /* background: #312E38; */
    color: #D85B5B;
    -webkit-font-smoothing: antialiased;
  }

  body, input, button {
    font-family: 'Karma', serif;
    font-size: 16px;
  }

  h1, h2, h3, h4, h5, strong {
    font-weight: 500;
  }

  button{
    cursor: pointer;
  }
`;
