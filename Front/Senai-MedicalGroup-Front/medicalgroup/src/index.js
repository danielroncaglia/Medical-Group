import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './pages/Home/App';
import Login from './pages/Login/Login';
import CadastrarConsulta from './pages/Consultas/CadastrarConsulta';
import ListarConsulta from './pages/Consultas/ListarConsulta';
//import ListarMedico from './pages/Consultas/ListarMedico';
//import AtualizarConsulta from './pages/Consultas/AtualizarConsulta';
//import ListarPaciente from './pages/Consultas/ListarPaciente';

import { usuarioAutenticado, parseJwt } from '../src/services/auth';
import NaoEncontrada from './pages/NaoEncontrada/NaoEncontrada';

import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import * as serviceWorker from '../src/serviceWorker';

const PermissaoAdm = ({component : Component}) => (
    <Route 
        render = {props => usuarioAutenticado() && parseJwt().Role === "Administrador" ?
            (<Component { ...props } />) :
            (<Redirect to={{ pathname : '/login', }} /> )
        }
    />
);

//const PermissaoMed = ({component : Component}) => (
//    <Route 
//        render = {props => usuarioAutenticado() && parseJwt().Role === "Medico" ?
//            (<Component { ...props } />) :
//            (<Redirect to={{ pathname : '/login', }} /> )
 //       }
//    />
//);

//const PermissaoPaciente = ({component : Component}) => (
//    <Route 
//        render = {props => usuarioAutenticado() && parseJwt().Role === "Paciente" ?
 //           (<Component { ...props } />) :
  //          (<Redirect to={{ pathname : '/login', }} /> )
   //     }
 //   />
//);

const 
rotas = (
    <Router>
        <div>
            <Switch>
                <Route exact path="/" component={App} />
                <Route path="/login" component={Login} />
                <PermissaoAdm path="/cadastrarconsulta" component={CadastrarConsulta} />
                <PermissaoAdm Route path="/listarconsulta" component={ListarConsulta} />
                <Route component={NaoEncontrada} />
            </Switch>
        </div>
    </Router>
);



//<PermissaoMed Route path="/atualizarconsulta" component={AtualizarConsulta} />
//
//<PermissaoPaciente Route path="/listarpaciente" component={ListarPaciente} />
//PermissaoMed <Route path="/listarmedico" component={ListarMedico} />

ReactDOM.render(rotas, document.getElementById('root'));

serviceWorker.unregister();