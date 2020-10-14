import React from 'react';
import { Switch, Route } from 'react-router-dom';
import SignInSignUp from '../pages/SignIn-SignUp';

const Routes: React.FC = () => (
  <Switch>
    <Route path="/" exact component={SignInSignUp} />
  </Switch>
);

export default Routes;
