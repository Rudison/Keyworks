import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeComponent } from './shared/home/home.component';
import { ColaboradorComponent } from './components/colaborador/colaborador.component';
import { TituloComponent } from './components/titulo/titulo.component';

import { ColaboradorService } from './services/Colaborador.service';
import { TituloService } from './services/Titulo.service';
import { TitulosTelasComponent } from './shared/TitulosTelas/TitulosTelas.component';
import { StatusCardService } from './services/StatusCard.service';
import { StatusCardComponent } from './components/statusCard/statusCard.component';
import { CardComponent } from './components/card/card.component';
import { SituacaoCardService } from './services/SituacaoCard.service';
import { SituacaoCardComponent } from './components/situacaoCard/situacaoCard.component';
import { PainelCardsService } from './services/PainelCards.service';
import { PainelCardComponent } from './components/painelCard/painelCard.component';
import { PaineisService } from './services/Paineis.service';
import { PainelComponent } from './components/Painel/Painel.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ColaboradorComponent,
    TituloComponent,
    TitulosTelasComponent,
    StatusCardComponent,
    CardComponent,
    SituacaoCardComponent,
    PainelCardComponent,
    PainelComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      progressAnimation: 'decreasing',
    }),
    NgxSpinnerModule,
    FormsModule,
  ],
  providers: [
    ColaboradorService,
    TituloService,
    StatusCardService,
    SituacaoCardService,
    PainelCardsService,
    PaineisService,
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
