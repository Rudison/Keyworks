import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardComponent } from './components/card/card.component';
import { ColaboradorComponent } from './components/colaborador/colaborador.component';
import { PainelCardComponent } from './components/painelCard/painelCard.component';
import { SituacaoCardComponent } from './components/situacaoCard/situacaoCard.component';
import { StatusCardComponent } from './components/statusCard/statusCard.component';
import { TituloComponent } from './components/titulo/titulo.component';

const routes: Routes = [
  {
    path: 'colaboradores',
    component: ColaboradorComponent,
  },
  {
    path: 'statusCard',
    component: StatusCardComponent,
  },
  {
    path: 'titulos',
    component: TituloComponent,
  },
  {
    path: 'situacaoCards',
    component: SituacaoCardComponent,
  },
  {
    path: 'cards',
    component: CardComponent,
  },
  {
    path: 'painelCards',
    component: PainelCardComponent,
  },
  {
    path: '',
    redirectTo: 'painelCards',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'painelCards',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
