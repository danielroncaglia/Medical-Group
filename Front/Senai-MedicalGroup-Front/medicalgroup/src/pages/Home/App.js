import React, { Component } from "react";


import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

class App extends Component {
  render() {
    return (

      <div>
        <header className="cabecalhoPrincipal">
          <div className="container">
          </div>
        </header>

        <section className="conteudoImagem">
          <div>
            <h1>Medical Group</h1>
          </div>
        </section>

        <main className="conteudoPrincipal">

          <section id="conteudoPrincipal-eventos">
            <div className="container">
              <nav>
                <ul className="conteudoPrincipal-dados">

                </ul>
              </nav>
            </div>
          </section>


        </main>

      </div>
    );
  }
}

export default App;