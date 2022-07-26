import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Titulo } from 'src/app/models/Titulo';
import { TituloService } from 'src/app/services/Titulo.service';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss'],
})
export class TituloComponent implements OnInit {
  modalRef?: BsModalRef;

  constructor(
    private tituloService: TituloService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.getTitulos();
  }

  public titulos: Titulo[] = [];
  public titulosFiltrados: Titulo[] = [];

  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.titulosFiltrados = this.filtroLista
      ? this.filtrarTitulos(this.filtroLista)
      : this.titulos;
  }

  public filtrarTitulos(filtrarPor: string): Titulo[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.titulos.filter(
      (colaborador: any) =>
        colaborador.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public getTitulos(): void {
    const observer = {
      next: (titulos: Titulo[]) => {
        this.titulos = titulos;
        this.titulosFiltrados = this.titulos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar Titulos', 'Erro!');
      },
      complete: () => {
        this.spinner.hide();
      },
    };

    this.tituloService.getTitulos().subscribe(observer);
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.toastr.success('Titulo excluido com sucesso', 'Excluido!');
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
