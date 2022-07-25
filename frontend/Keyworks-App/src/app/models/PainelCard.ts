import { SituacaoCard } from './SituacaoCard';

export interface PainelCard {
  id: number;
  situacaoId: number;
  ordemCard: number;
  posicaoVertical: number;
  posicaoHorizontal: number;
  situacaoCard: SituacaoCard;
}
