import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { SituacaoCard } from 'src/app/models/SituacaoCard';
import { SituacaoCardService } from 'src/app/services/SituacaoCard.service';

@Component({
  selector: 'app-situacaoCard',
  templateUrl: './situacaoCard.component.html',
  styleUrls: ['./situacaoCard.component.scss'],
})
export class SituacaoCardComponent implements OnInit {
  modalRef?: BsModalRef;

  constructor(
    private situacaoCardService: SituacaoCardService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.getSituacaoCards();
  }

  public situacaoCards: SituacaoCard[] = [];
  public situacaoCardsFiltrados: SituacaoCard[] = [];

  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.situacaoCardsFiltrados = this.filtroLista
      ? this.filtrarSitucao(this.filtroLista)
      : this.situacaoCards;
  }

  public filtrarSitucao(filtrarPor: string): SituacaoCard[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.situacaoCards.filter(
      (situacaoCards: any) =>
        situacaoCards.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public getSituacaoCards(): void {
    const observer = {
      next: (statusCard: SituacaoCard[]) => {
        this.situacaoCards = statusCard;
        this.situacaoCardsFiltrados = this.situacaoCards;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar Situacao', 'Erro!');
      },
      complete: () => {
        this.spinner.hide();
      },
    };

    this.situacaoCardService.getSituacaoCards().subscribe(observer);
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.toastr.success('Status Card excluido com sucesso', 'Excluido!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
